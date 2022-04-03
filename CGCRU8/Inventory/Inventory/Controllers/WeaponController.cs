using Commands;
using ConsoleTables;
using Inventory;
using Types;

namespace Controllers
{
    internal class WeaponController : ItemController<IManageWeapons, Weapon>
    {
        public WeaponController() : base("allWeaponsFile", "Fegyverek") { }

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
    }
}
