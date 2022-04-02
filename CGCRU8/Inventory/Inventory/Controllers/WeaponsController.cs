using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    internal class WeaponsController : IItemController
    {
        public bool Manage()
        {
            while (true)
            {
                Console.WriteLine("Manage Weapons");
                break;
            }

            return true;
        }
    }
}
