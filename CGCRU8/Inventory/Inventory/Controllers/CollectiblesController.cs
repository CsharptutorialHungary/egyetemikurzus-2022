using Commands;
using ConsoleTables;
using Inventory;
using Types;

namespace Controllers
{
    internal class CollectiblesController : ItemController<IManageCollectibles, Collectible>
    {
        public CollectiblesController() : base("allItemsFile", "Tárgyak") {}

        public override bool Manage()
        {
            while (true)
            {
                Console.WriteLine("Manage Collectibles");
                break;
            }


            return true;
        }

        protected override void ConstructConsoleTable()
        {
            Console.WriteLine("\n\tMit szeretnél csinálni?");

            ConsoleTable table = new ConsoleTable("Parancs", "Leírás");
            table.AddRow("listAll", "Összes tárgy kilistázása");
            table.AddRow("listByCategory", "Tárgyak listázása kategóriánként");
            table.AddRow("detail nameOfTheItem", "Tárgy adatainak megtekintése");

            table.AddRow("", "");
            table.AddRow("back", "Vissza a főmenübe");

            table.Write();

            Console.Write("> ");
        }
    }
}
