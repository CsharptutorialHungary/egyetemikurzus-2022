using ConsoleTables;
using Types;
using Inventory;
using ItemHandler;
using System.Configuration;
using Commands;

namespace Controllers
{
    internal class ItemController<ItemType> where ItemType : Item
    {
        private readonly Dictionary<string, IManageItems> commands;
        private readonly List<ItemType>? items;

        private readonly string category;
        private readonly string categoryPlural;
        private readonly string categoryEnglish;

        public ItemController(string file, string category, string categoryPlural, string categoryEnglish)
        {
            commands = new Dictionary<string, IManageItems>();

            foreach (var command in Controller.LoadCommands<IManageItems>().ToDictionary(x => x.GetType().Name.ToLower(), x => x))
                commands.Add(command.Key, command.Value);

            items = Serializer.LoadItems<ItemType>(ConfigurationManager.AppSettings[file], categoryPlural);

            this.category = category;
            this.categoryPlural = categoryPlural;
            this.categoryEnglish = categoryEnglish;
        }

        public bool Manage()
        {
            if (items == null)
                return false;

            while (true)
            {
                ConstructConsoleTable();
                string? action = Console.ReadLine();

                if (string.IsNullOrEmpty(action) || action.ToLower() == "back")
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

        private string GetArgsFromCommand(string command)
        {
            if (!command.Contains(" "))
                return "";

            List<string> args = new List<string>(command.Split(" "));

            return string.Join(" ", args.GetRange(1, args.Count - 1));
        }

        public static void ListItemsInGrid<T>(List<T> items) where T : Item
        {
            ConsoleTable table = new ConsoleTable("", "", "");

            List<string> names = new List<string>();
            for (int i = 1; i <= items.Count; i++)
            {
                names.Add(items[i - 1].Name);

                if (i % 3 == 0)
                {
                    table.AddRow(names[0], names[1], names[2]);
                    names.Clear();
                }
            }

            while (names.Count < 3)
                names.Add("");

            if(names[0] != "")
                table.AddRow(names[0], names[1], names[2]);

            table.Write();
        }

        private void ConstructConsoleTable()
        {
            Console.WriteLine("\n\tMit szeretnél csinálni?");

            ConsoleTable table = new ConsoleTable("Parancs", "Leírás");
            table.AddRow("listAll", $"Összes {category.ToLower()} kilistázása");
            table.AddRow("listByCategory", $"{categoryPlural} listázása kategóriánként");
            table.AddRow($"detail nameOfThe{categoryEnglish}", $"{category} adatainak megtekintése");

            table.AddRow("", "");
            table.AddRow("back", "Vissza a főmenübe");

            table.Write();

            Console.Write("> ");
        }
    }
}
