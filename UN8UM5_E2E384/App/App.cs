using Szalloda.UI;
using Szalloda.AppBack;
using Szalloda.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

InitData.InitializeData();



AppUI.Welcome();

string username = Utility.GetUserInput("username");
Console.WriteLine(username);

// hides the password
System.Console.Write("password: ");
string password = null;
while (true)
{
    var key = System.Console.ReadKey(true);
    if (key.Key == ConsoleKey.Enter)
        break;
    password += key.KeyChar;
}
Console.WriteLine("\nBooking: ");

// TODO : ellenőrizni, hogy a beírt felhasználónév/jelszó páros megfelelő-e
// isSuccess

GetGuestInformation();

void GetGuestInformation() {
    int guestListLength = 0;
    string name = Utility.GetUserInput("Name: ");
    int age = Utility.GetUserInputInt("Age: ");
    int reservedroom = Utility.GetUserInputInt("Room number: ");
    int adults = Utility.GetUserInputInt("Adults:");
    int children = Utility.GetUserInputInt("Children: ");
    string phonenumber = Utility.GetUserInput("Phone: ");
    string email = Utility.GetUserInput("Email: ");
    DateTime arrival = Utility.GetUserInputDate("Arrival (YYYY/MM/DD): ");
    DateTime departure = Utility.GetUserInputDate("Departure (YYYY/MM/DD): ");

    //teszt
    List<Guest> guestList = new List<Guest> { };

    if (File.Exists(@"../../../../Reservations.json"))
    {
        try
        {
            string oldGuestList = File.ReadAllText(@"../../../../Reservations.json");
            guestList = JsonSerializer.Deserialize<List<Guest>>(oldGuestList);
        }
        catch (Exception ex) when (ex is IOException || ex is JsonException)
        {
            Console.WriteLine(ex.ToString());
        }
        guestListLength = guestList.Count;
    }
     
    guestList.Add(new Guest
    {
        Id = guestListLength + 1,
        Name = name,
        Age = age,
        ReservedRoomId = reservedroom,
        Adults = adults,
        Children = children,
        PhoneNumber = phonenumber,
        Email = email,
        ArrivalDate = arrival,
        DepartureDate = departure
    });

    try
    {
        string jsonEncoded = JsonSerializer.Serialize(guestList, new JsonSerializerOptions
        {
            WriteIndented = true,
        });
        File.WriteAllText(@"../../../../Reservations.json", jsonEncoded);
        Console.WriteLine("Room reserved");
    }
    catch (Exception ex) when (ex is IOException || ex is JsonException)
    {
        Console.WriteLine(ex.ToString());
    }
}
