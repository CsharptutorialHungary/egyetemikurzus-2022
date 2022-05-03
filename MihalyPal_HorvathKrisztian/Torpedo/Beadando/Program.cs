using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml;

namespace Beadando
{
    internal class Program
    {
        static void TablakFilebaMentese(JatekTabla jatekosTablaja, JatekTabla ellenfelTablaja, int szelesseg, int magassag)
        {
            File.AppendAllText(@"Tablak.txt", "A játékos táblája \n");

            for (int i = 0; i < magassag; i++)
            {
                for (int j = 0; j < szelesseg; j++)
                {
                    string elem = jatekosTablaja.Palya[i, j].ToString();
                    File.AppendAllText(@"Tablak.txt", " " + elem + " ");

                }
                File.AppendAllText(@"Tablak.txt", "\n");

            }
            File.AppendAllText(@"Tablak.txt", "A gép táblája \n");
            for (int i = 0; i < magassag; i++)
            {
                for (int j = 0; j < szelesseg; j++)
                {
                    string elem = ellenfelTablaja.Palya[i, j].ToString();
                    File.AppendAllText(@"Tablak.txt", " " + elem + " ");

                }
                File.AppendAllText(@"Tablak.txt", "\n");

            }

        }
        static void Main(string[] args)
        {


            //Ellenfél táblájának generálása
            JatekTabla ellenfelTabla = new JatekTabla(10, 10);

            ellenfelTabla.PalyatGeneral();
            Console.WriteLine("Az ellenfél táblái randomok legyenek, vagy JSON filebol olvasod be ?(J || R)");
            string RandomEllenfeltAkarunk = Console.ReadLine();

            string JsonString = "";

            if (RandomEllenfeltAkarunk == "R")
            {
                for (int i = 0; i < 6; i++)
                {

                    while (true)
                    {
                        Random rnd = new Random();
                        ellenfelTabla.Hajok[i].X = rnd.Next(0, 10);
                        ellenfelTabla.Hajok[i].Y = rnd.Next(0, 10);
                        ellenfelTabla.Hajok[i].Orientacio = rnd.Next(1, 3);

                        if (ellenfelTabla.HajoLehelyezhetoE(ellenfelTabla.Hajok[i]) == true)
                        {
                            ellenfelTabla.HajotElhelyez(ellenfelTabla.Hajok[i]);

                            break;
                        }


                    }
                }

                List<Hajo> hajok = new List<Hajo>();

                for (int i = 0; i < 6; i++)
                {
                    hajok.Add(ellenfelTabla.Hajok[i]);
                    //JsonString = JsonConvert.SerializeObject(hajok, Newtonsoft.Json.Formatting.Indented);

                    //File.WriteAllText(@"EllenfelHajoi.json", JsonString);


                }
                var eredmeny = from hajo in hajok
                               orderby hajo.Tipus descending
                               select hajo;
                File.WriteAllText(@"EllenfelHajoi.json", "[");
                int l = 0;
                foreach (var egyHajo in eredmeny)
                {
                    JsonString = JsonConvert.SerializeObject(egyHajo, Newtonsoft.Json.Formatting.Indented);

                    if (l < 5)
                    {
                        JsonString += ",";
                    }

                    File.AppendAllText(@"EllenfelHajoi.json", JsonString);
                    l++;
                }

                File.AppendAllText(@"EllenfelHajoi.json", "]");
                // Ez a rész arra van, ha szeretnénk egy JSON fileba menteni a random pozíciót, h ne magunknak kelljen megírni


            }
            else
            {
                JsonString = System.IO.File.ReadAllText(@"EllenfelHajoi.json");
                List<Hajo> hajok = new List<Hajo>();
                hajok = System.Text.Json.JsonSerializer.Deserialize<List<Hajo>>(JsonString);
                for (int i = 0; i < 6; i++)
                {
                    ellenfelTabla.Hajok[i] = hajok[i];
                    Console.WriteLine(ellenfelTabla.Hajok[i].Orientacio);
                    if (ellenfelTabla.HajoLehelyezhetoE(ellenfelTabla.Hajok[i]) == true)
                    {
                        ellenfelTabla.HajotElhelyez(ellenfelTabla.Hajok[i]);


                    }
                }
            }


            Console.Clear();
            // ellenfelTabla.tablatKiir();
            //Ellenfél táblájának generálásának a vége
            Console.WriteLine("A hajók pozícióit úgy kell megadni, hogy megadod az X és Y koordinátákat, majd azt, hogy \n milyen" +
                "irányban legyen elforgatva. Ezeknek a leírása a következő:\n" +
                "1: ez az alapértelmezett, ilyenkor vízszintesen van elhelyezve a hajó.\n" +
                "2: ez a függőleges elhelyezés.\n" +
                "figyelj majd arra, hogy a hajók ne lógjanak ki a pályáról szóval az általad megadott pozíciótól\n" +
                "mindig számolj el annyi blokkot, jobbra,vagy lefele amilyen típusú  a hajód!");

            JatekTabla jatekTabla = new JatekTabla(10, 10);
            JatekTabla lovoTabla = new JatekTabla(10, 10);
            jatekTabla.PalyatGeneral();
            lovoTabla.PalyatGeneral();
            AdatokatBeker bekeres = new AdatokatBeker();
            Boolean jatekban = true;
            jatekTabla.tablatKiir();
            for (int i = 0; i < jatekTabla.Hajok.Count; i++)
            {
                Boolean joVoltE = false;
                while (joVoltE == false)
                {

                    bekeres.BekerHajot(jatekTabla.Hajok[i]);
                    joVoltE = jatekTabla.HajoLehelyezhetoE(jatekTabla.Hajok[i]);

                }

                if (joVoltE == true)
                {
                    jatekTabla.HajotElhelyez(jatekTabla.Hajok[i]);
                    Console.Clear();
                    jatekTabla.tablatKiir();
                }

            }
            TablakFilebaMentese(jatekTabla, ellenfelTabla, 10, 10);
            Console.WriteLine();
            int xGepiTalalat = -1;
            int yGepiTalalat = -1;
            int irany = 1; // 1 2 3 4
            int nehezsegTenyezo = 0;
            int kiJon = 0;
            while (true)
            {

                if (kiJon == 0)
                {
                    Console.Clear();
                    Console.WriteLine("A saját táblád:");
                    jatekTabla.tablatKiir();
                    ellenfelTabla.tablatKiir();
                    Console.WriteLine("A a lövőtáblád:");
                    lovoTabla.tablatKiir();

                    int[] loveseim = bekeres.BekerLovest();
                    Boolean sullyedtE = ellenfelTabla.hajotLoJatekos(loveseim[0], loveseim[1], lovoTabla);
                    if (sullyedtE == true)
                    {
                        Console.WriteLine("Gratulálalok, talált süllyedt!");
                    }
                    String str = Console.ReadLine();
                    if (str == "vege")
                    {
                        break;
                    }
                    kiJon = 1;
                }
                else if (kiJon == 1)
                {

                    nehezsegTenyezo = jatekTabla.hajotLoGep(nehezsegTenyezo);
                    kiJon = 0;
                    if (jatekTabla.jatszhatMeg() == false)
                    {
                        Console.WriteLine(" Az ellenség adatai:");
                        ellenfelTabla.eletbenMaradtHajok();
                        Console.WriteLine("Vesztettél! A 'zseniális' algoritmusom legyőzött !!! ");
                        break;
                    }
                }

                if (ellenfelTabla.jatszhatMeg() == false)
                {
                    jatekTabla.eletbenMaradtHajok();
                    Console.WriteLine("Gratulálok, győztél...");
                    break;

                }

            }
        }
    }
}
