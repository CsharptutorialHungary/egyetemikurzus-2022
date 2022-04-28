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
        public static List<UserAccount> userAccountList;
        public static UserAccount selectedAccount;

        public static List<Guest> guestList;
        public static Guest selectedGuest;

        public static List<Room> roomList;
        public static Room selectedRoom;
        public static void InitializeData()
        {
            userAccountList = new List<UserAccount>
            {
                new UserAccount{Id=1, UserName="Teszt Elek", Password="password"}
            };
            guestList = new List<Guest>
            {
                // TODO : folytatni
                new Guest{Id=1, Name="Zsák Imre", Age=22, ReservedRoomId=1, Adults=2, Children=1, PhoneNumber="06305552233", Email="zsakosfrodo123@gmail.com",
                    ArrivalDate= new DateTime(2022, 10, 10), DepartureDate= new DateTime(2022, 10, 12)},
            };
            roomList = new List<Room>
            {
                new Room{Id=1, Type="Luxury", NumberOfPeopleCanSleep=2}
            };
        }



    }
}