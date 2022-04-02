using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    internal class RingsController : IItemController
    {
        public bool Manage()
        {
            while (true)
            {
                Console.WriteLine("Manage Rings");
                break;
            }

            return true;
        }
    }
}
