using System.Collections.Generic;
using System.Text.Json;
using TornamentResults;

List<DataType> GetJsonList(string path){
    try
    {
        string InFile = File.ReadAllText(path + @"\JsonDataHolder.json");
        List<DataType> inData = JsonSerializer.Deserialize<List<DataType>>(InFile);
        return inData;
    }catch (FileNotFoundException e)
    {
        Console.WriteLine("Fájl újonnan létrehozva.");
        return new List<DataType>();
    }catch (Exception e)
    {
        Console.WriteLine(e.Message);
        return null;
    }
}

void SaveJson(DataType dataType, string path)
{
    var JsonList = GetJsonList(path);
    if (JsonList == null) return;
    JsonList.Add(dataType);
    try
    {
        string jsonEncoded = JsonSerializer.Serialize(JsonList, new JsonSerializerOptions
        {
            WriteIndented = true,
        });
        File.WriteAllText(path + @"\JsonDataHolder.json", jsonEncoded);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void listAll(List<DataType> JsonList, string? filter=null)
{
    if(filter != null)
    {
        var results=JsonList.Where(x => x.Tournament.Equals(filter));
        foreach (var result in results)
        {
            Console.WriteLine(result.toString());
            Console.WriteLine();
        }
    }
    else
    {
        foreach (var ListItem in JsonList)
        {
            Console.WriteLine(ListItem.toString());
            Console.WriteLine();
        }
    }
    Console.WriteLine();
}

void listTeamStat(List<DataType> JsonList, string filter)
{
    var NumberOfGames= (from element in JsonList
                 where element.Home.Equals(filter) || element.Guest.Equals(filter)
                 select element).Count();
    var GoalsAsHome = (from element in JsonList
                       where element.Home.Equals(filter)
                       select element.HomeScore).Sum();
    var GoalsAsGuest = (from element in JsonList
                        where element.Guest.Equals(filter)
                        select element.GuestScore).Sum();
    var PlayedTournaments = JsonList.Where(x => x.Home.Equals(filter) || x.Guest.Equals(filter))
        .GroupBy(group => group.Tournament)
        .Select(x => x.First());
    Console.WriteLine("A '"+filter+"' csapat eddig "
        + GoalsAsHome + " gólt lőtt, mint hazai csapat, "
        + GoalsAsGuest + " gólt, mint vendég, összesen "+
        (GoalsAsGuest +GoalsAsHome) + "-t.");
    Console.WriteLine("Eddig a következő bajnokságokon játszottak:");
    foreach (var PlayedTournament in PlayedTournaments)
    {
        Console.WriteLine(PlayedTournament.Tournament);
    }
    Console.WriteLine();


}

//jelenlegi working dir-ig az útvonal, a fájlok olvasásakor, mentésekor lesz rá szükség
string CurrentWorkingDirectory=System.IO.Directory.GetCurrentDirectory();

//van-e jogunk felvenni mérkőzést
Boolean WritingPrivileg = true;

//egy ciklus végigérésekor lehetőség kilépni
int FirstRun = 0;
Console.WriteLine("Üdvözöljük, az alkalmazásban mérkőzéseket adminisztrálhat, vagy megtekintheti azok eredményeit.");
while (true)
{
    //kilépés
    if (FirstRun != 0)
    {
        System.Threading.Thread.Sleep(500);
        Console.WriteLine("Ha nem kívája folytatni küldje el a 'q' karaktert! Bármely másik input hatására a program futása folytatódik.");
        if (Console.ReadLine().Trim() == "q") break;
    }
    else
    {
        FirstRun++;
    }
    Console.WriteLine("Mit kíván tenni?\nMeccs felvétele: 'f' billentyű lenyomásával\nMeccsek listázása: 'l' billentyű lenyomásával");
    string? WhatToDo=Console.ReadLine();

    //meccs felvétele
    if (WhatToDo.Trim() == "f" && WritingPrivileg)
    {
        Console.WriteLine("Bajnokság: ");
        string? Tournament=Console.ReadLine();
        Console.WriteLine("Hazai csapat:");
        string? Home = Console.ReadLine();
        Console.WriteLine("Vendég csapat:");
        string? Guest = Console.ReadLine();
        Console.WriteLine("Meg akar vesztegetni?: (i: igen, bármely más input nemnem tekintett)");
        Boolean GiveMoney = Console.ReadLine().Trim()=="i" ? true : false;
        if (Tournament!=null && Home!=null && Guest != null)
        {
            //adatok mentése fájlba
            try
            {
                DataType Game = new DataType(Tournament, Home, Guest, GiveMoney);
                Console.WriteLine("Felvett mérkőzés eredménye: ");
                Console.WriteLine(Game.toString());
                Task.Run(() => SaveJson(Game, CurrentWorkingDirectory));
                continue;
            //a két csapat neve nem lehet ugyan az
            }catch(ArgumentException SameName)
            {
                Console.WriteLine(SameName.Message);
                continue;
            }
            //sikertelen megvesztegetésért nem vehet több meccset fel
            catch (Exception ex)
            {
                WritingPrivileg = false;
                Console.WriteLine(ex.Message);
                continue;
            }
        }
        else
        {
            //hiányzó paraméter
            Console.WriteLine("Az adatok megadása kötelező, próbálja újra!");
            continue;
        }

    // adatlekérő mód
    }else if(WhatToDo.Trim() == "l")
    {
        var JsonList = GetJsonList(CurrentWorkingDirectory);
        if (JsonList == null) return;
        Console.WriteLine("Mit kíván látni? (Figyelem, az input Case sensitive!)\n\tMindent: 'a'\n\tBajnokságra szűrés: 'b {Bajnokságnév}'\n\tCsapat statisztikái: 'stat {Csapatnév}'");
        string? answer = Console.ReadLine();
        //kiírási mód választása
        if (answer == "a")
        {
            listAll(JsonList);
        }
        else
        {
            string[]? parts=answer.Split(' ');
            if(parts[0].Trim()=="b" && parts[1] !=null)
            {
                listAll(JsonList, parts[1].Trim());
            }else if(parts[0].Trim() =="stat" && parts[1] !=null)
            {
                listTeamStat(JsonList, parts[1].Trim());
            }
            else
            {
                Console.WriteLine("Sajnos nem megfelelő parancsot adott meg! Próbálja meg újra!");
                continue;
            }
        }
    }
    else
    {
        //nem f-et vagy l-t nyomott a user
        Console.WriteLine("Ismeretlen billentyű, próbálja újra!");
        continue;
    }
}

