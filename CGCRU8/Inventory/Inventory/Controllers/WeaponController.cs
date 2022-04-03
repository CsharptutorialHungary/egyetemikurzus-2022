using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    internal class WeaponController : ItemController
    {
        public override bool Manage()
        {
            while (true)
            {
                Console.WriteLine("Manage Weapons");
                break;
            }

            return true;
        }

        protected override void ConstructConsoleTable()
        {
            throw new NotImplementedException();
        }

        protected override string GetArgsFromCommand(string command)
        {
            throw new NotImplementedException();
        }
    }
}
