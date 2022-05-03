using Szalloda.UI;
using Szalloda.AppBack;
using Szalloda.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using System.Linq;

InitData.InitializeData();
AppUI.Welcome();

AdminLogIn();
OptionMenu();


void OptionMenu()
{
    bool finished = false;
    do
    {

        Console.WriteLine("\n\nChoose what would you like to do:");
        Console.WriteLine("1 - Book");
        Console.WriteLine("2 - Guests leaving today");
        Console.WriteLine("3 - Room reservations");
        Console.WriteLine("4 - Longest reservation");
        Console.WriteLine("5 - Youngest guest");
        Console.WriteLine("9 - Quit\n");

        int option = int.Parse(Utility.GetUserInput("Option: "));


        if (option == 9)
        {
            finished = true;
        }
        else
        {
            finished = false;
        }


        switch (option)
        {
            case 1:
                GetGuestInformation();
                break;
            case 2:
                GuestsLeavingToday();
                break;
            case 3:
                ReservationsByRoom();
                break;
            case 4:
                LongestReservation();
                break;
            case 5:
                YoungestGuest();
                break;
        }

    } while (!finished);

    
}

//Serialize, Deserialize
void GetGuestInformation() {

    Console.WriteLine("\n====== Booking ======");

    int guestListLength = InitData.guestList.Count;
    string name = Utility.GetUserInput("Name: ");
    int age = Utility.GetUserInputInt("Age: ");
    int reservedroom = Utility.GetUserInputInt("Room number: ");
    int adults = Utility.GetUserInputInt("Adults:");
    int children = Utility.GetUserInputInt("Children: ");
    string phonenumber = Utility.GetUserInput("Phone: ");
    string email = Utility.GetUserInput("Email: ");
    DateTime arrival = Utility.GetUserInputDate("Arrival (YYYY/MM/DD): ");
    DateTime departure = Utility.GetUserInputDate("Departure (YYYY/MM/DD): ");

    InitData.guestList.Add(new Guest
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

    WriteReservationToJSON(InitData.guestList);
}


void WriteReservationToJSON(List<Guest> list)
{
    try
    {
        string jsonEncoded = JsonSerializer.Serialize(InitData.guestList, new JsonSerializerOptions
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

void AdminLogIn()
{
    while (true)
    {
        if (LogInAsAdmin())
        {
            break;
        }
        else if (System.Console.ReadKey(true).Key == ConsoleKey.Q)
        {
            Environment.Exit(0);
        }
    }
}

//Record class equality
bool LogInAsAdmin()
{
    bool admin = false;
    string username = Utility.GetUserInput("username");

    System.Console.Write("password: ");
    string password = null;
    while (true)
    {
        var key = System.Console.ReadKey(true);
        if (key.Key == ConsoleKey.Enter)
            break;
        password += key.KeyChar;
    }

    AdminAccount userInput = new AdminAccount(username, password);
    foreach (var adminAccount in InitData.adminAccountList)
    {
        if (adminAccount == userInput)
        {
            admin = true;
            break;
        }
    }

    if (admin)
    {
        Console.WriteLine("\nLogged in as {0}.", userInput.UserName);
    }
    else
    {
        Console.WriteLine("\nLogin failed. Press q to exit or any other key to try again.");
        // Environment.Exit(0);
    }
    return admin;
}

//LINQ where
void GuestsLeavingToday() {
    var todaysDepartures = from guest in InitData.guestList
    where guest.DepartureDate == DateTime.Today
    select new List<string> { guest.Name, guest.ReservedRoomId.ToString()};

    Console.WriteLine("\n====== Guests leaving today ======");
    foreach (var todaysDeparture in todaysDepartures)
    {
        Console.WriteLine("{0}, room: {1}", todaysDeparture[0], todaysDeparture[1]);
    }
}

//LINQ order by, group by
void ReservationsByRoom()
{
    var roomReservationsQuery = from guest in InitData.guestList
    group guest by guest.ReservedRoomId into roomReservations
    orderby roomReservations.Key
    select roomReservations;

    Console.WriteLine("\n====== Room reservations ======");
    foreach (var roomGroup in roomReservationsQuery)
    {
        Console.WriteLine("\nRoom: {0}", roomGroup.Key);
        foreach (var reservation in roomGroup)
        {
            Console.WriteLine("\t{0}, {1} - {2}", reservation.Name, reservation.ArrivalDate.ToString("yyyy-MM-dd"), reservation.DepartureDate.ToString("yyyy-MM-dd"));
        }
    }
}

//LINQ Max()
void LongestReservation()
{
    var reservationLengths = new List<TimeSpan>();
    foreach (var reservation in InitData.guestList)
    {
        reservationLengths.Add(reservation.DepartureDate.Subtract(reservation.ArrivalDate));
    }

    var longestReservationQuery = from guest in InitData.guestList
    where (guest.DepartureDate - guest.ArrivalDate) == reservationLengths.Max()
    select new List<string> { guest.Name, guest.ReservedRoomId.ToString(), guest.PhoneNumber, guest.Email, reservationLengths.Max().Days.ToString()};

    Console.WriteLine("\n====== Longest reservation ======");
    foreach (var longest in longestReservationQuery)
    {
        Console.WriteLine("Name: {0}, room: {1}, phone: {2}, email: {3}, length: {4} days", longest[0], longest[1], longest[2], longest[3], longest[4]);
    }
}

//LINQ Min()
void YoungestGuest()
{
    var guestAges = new List<int>();
    foreach (var guest in InitData.guestList)
    {
        guestAges.Add(guest.Age);
    }

    var youngestGuestQuery = from guest in InitData.guestList
                        where guest.Age == guestAges.Min()
                        select new List<string> { guest.Name, guest.Age.ToString()};

    Console.WriteLine("\n====== Youngest guest ======");
    foreach (var youngest in youngestGuestQuery)
    {
        Console.WriteLine("Name: {0}, age: {1}", youngest[0], youngest[1]);
    }
}