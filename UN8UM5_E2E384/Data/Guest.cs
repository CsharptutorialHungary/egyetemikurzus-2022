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
        public int Age { get; set; }
        public int ReservedRoomId { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
