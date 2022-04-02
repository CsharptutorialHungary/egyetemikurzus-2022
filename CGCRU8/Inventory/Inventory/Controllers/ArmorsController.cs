using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    internal class ArmorsController : IItemController
    {
        public bool Manage()
        {
            while(true)
            {
                Console.WriteLine("Manage Armors");
                break;
            }

            return true;
        }
    }
}
