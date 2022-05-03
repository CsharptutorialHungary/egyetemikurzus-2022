using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

using Szalloda.Data;

namespace Szalloda.AppBack
{
    internal class InitData
    {
        public static List<UserAccount> userAccountList;
        public static UserAccount selectedAccount;

        public static List<Guest> guestList;
        public static Guest selectedGuest;

        public static List<Room> roomList;
        public static Room selectedRoom;

        public static List<AdminAccount> adminAccountList;
        public static AdminAccount selectedAdminAccount;
        public static void InitializeData()
        {
            userAccountList = new List<UserAccount>
            {
                new UserAccount{Id=1, UserName="Teszt Elek", Password="password"}
            };
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
            }
            roomList = new List<Room>
            {
                new Room{Id=1, Type="Luxury", NumberOfPeopleCanSleep=2}
            };
            adminAccountList = new List<AdminAccount>
            {
                new AdminAccount("admin","admin"),
                new AdminAccount("joe","joe")
            };
        }



    }
}