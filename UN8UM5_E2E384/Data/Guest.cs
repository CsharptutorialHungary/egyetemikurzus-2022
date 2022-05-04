using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szalloda.Data
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value <= 18)
                { _age = 18; }
                else if (value > 99)
                {
                    _age = 99;
                }
            }
        }

        public int ReservedRoomId { get; set; }

        public int _adults;
        public int Adults
        {
            get { return _adults; }
            set
            {
                if (value <= 0)
                {
                    _adults = 1;
                }
            }
        }

        public int _children;
        public int Children
        {
            get { return _children; }
            set
            {
                if (value < 0)
                {
                    _children = 0;
                }
            }
        }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        // MailAddress m = new MailAddress(emailaddress);
        public DateTime ArrivalDate { get; set; }

        public DateTime _departureDate;
        public DateTime DepartureDate
        {
            get { return _departureDate; }
            set
            {
                if (value <= ArrivalDate)
                {
                    _departureDate = ArrivalDate.AddDays(1);
                }
            }
        }
    }
}
