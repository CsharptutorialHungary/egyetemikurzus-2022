using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szalloda.Data
{
    internal class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int _age;
        public int Age { get; }
        public void SetAge()
        {
            if (Age <= 18)
            {
                _age = 18;
            }
            else if (Age > 99)
            {
                _age = 99;
            }
        }
        public int ReservedRoomId { get; set; }

        public int _adults;
        public int Adults { get; }
        public void SetAdults()
        {
            if (Adults <= 0)
            {
                _adults = 1;
            }
        }

        public int _children;
        public int Children { get; }
        public void SetChildren()
        {
            if (Children < 0)
            {
                _children = 0;
            }

        }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        // MailAddress m = new MailAddress(emailaddress);
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
