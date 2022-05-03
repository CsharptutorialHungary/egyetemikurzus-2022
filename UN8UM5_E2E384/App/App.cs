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
    List<Guest> guestList = new List<Guest>
            {
                // TODO : folytatni
                new Guest{Id=1, Name="Zsak Imre", Age=22, ReservedRoomId=1, Adults=2, Children=1, PhoneNumber="06305552233", Email="zsakosfrodo123@gmail.com",
                    ArrivalDate= new DateTime(2022, 10, 10), DepartureDate= new DateTime(2022, 10, 12)},
            };

    guestList.Append(new Guest
    {
        Id = 2,
        Name = name,
        Age = age,
        ReservedRoomId = reservedroom,
        Adults = adults,
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
        File.WriteAllText(@"c:\Szalloda\Reservations.json", jsonEncoded);
    }
    catch (Exception ex) when (ex is IOException || ex is JsonException)
    {
        Console.WriteLine(ex.ToString());
    }
}
