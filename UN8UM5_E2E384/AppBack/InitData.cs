using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Szalloda.Data;

namespace Szalloda.AppBack
{
    internal class InitData
    {
        private static List<UserAccount> userAccountList;
        private static UserAccount selectedAccount;

        private static List<Guest> guestList;
        private static Guest selectedGuest;

        private static List<Room> roomList;
        private static Room selectedRoom;
        public static void InitializeData()
        {
            userAccountList = new List<UserAccount>
            {
                new UserAccount{Id=1, UserName="Teszt Elek", Password="password"}
            };
            guestList = new List<Guest>
            {
                // TODO : folytatni
                new Guest{Id=1, Name="Zsák Imre", Age=22, ReservedRoomId=1, NumberOfPeople=2, PhoneNumber="06305552233", Email="zsakosfrodo123@gmail.com",
                    ArrivalDate= new DateOnly(2022, 10, 10), DepartureDate= new DateOnly(2022, 10, 12)},
            };
            roomList = new List<Room>
            {
                new Room{Id=1, Type="Luxury", NumberOfPeopleCanSleep=2}
            };
        }



    }
}