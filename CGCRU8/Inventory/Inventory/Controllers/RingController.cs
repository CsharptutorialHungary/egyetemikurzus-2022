using Commands;
using ConsoleTables;
using Inventory;
using Types;


namespace Controllers
{
    internal class RingController : ItemController<IManageRings, Ring>
    {
        public RingController() : base("allRingsFile", "Gyűrűk") {}

        public override bool Manage()
        {
            while (true)
            {
                Console.WriteLine("Manage Rings");
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
