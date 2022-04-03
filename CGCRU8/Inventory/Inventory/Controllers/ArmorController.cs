using Commands;
using ConsoleTables;
using Inventory;
using Types;

namespace Controllers
{
    internal class ArmorController : ItemController<IManageArmors, Armor>
    {
        public ArmorController() : base("allArmorsFile", "Páncélok") {}

        public override bool Manage()
        {
            if (items == null)
                return false;

            while (true)
            {
                ConstructConsoleTable();
                string? action = Console.ReadLine();

                if (string.IsNullOrEmpty(action) || action.ToLower() == "close")
                    break;

                action = action.ToLower();
                Logger.Log(action);

                string arg = GetArgsFromCommand(action);
                action = action.Split(" ")[0];

                Console.WriteLine("\n\n\n\n");

                bool error = false;
                if (commands.ContainsKey(action))
                    error = !commands[action].Execute(items, arg);
                else
                    Console.WriteLine($"Ismeretlen parancs: {action}!");

                if (error)
                {
                    Console.WriteLine($"Hiba lépett fel a(z) {action} parancs futtatása közben. Bővebb információ a log fájlban.\n\n" +
                                      $"A folytatáshoz nyomj meg egy gombot...");
                    Console.ReadKey();
                }
            }

            return true;
        }

        protected override void ConstructConsoleTable()
        {
            Console.WriteLine("\n\tMit szeretnél csinálni?");

            ConsoleTable table = new ConsoleTable("Parancs", "Leírás");
            table.AddRow("listAll", "Összes páncél kilistázása");
            table.AddRow("listByCategory", "Páncélok listázása kategóriánként");
            table.AddRow("detail nameOfTheArmor", "Páncél adatainak megtekintése");

            table.AddRow("", "");
            table.AddRow("back", "Vissza a főmenübe");

            table.Write();

            Console.Write("> ");
        }
    }
}
