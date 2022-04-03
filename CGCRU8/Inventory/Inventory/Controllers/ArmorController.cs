using Commands;
using ConsoleTables;
using Inventory;
using ItemHandler;
using Types;
using System.Configuration;

namespace Controllers
{
    internal class ArmorController : ItemController
    {
        private readonly Dictionary<string, IManageArmors> commands;
        private readonly List<Armor>? armors;

        public ArmorController()
        {
            commands = new Dictionary<string, IManageArmors>();

            foreach (var command in Controller.LoadCommands<IManageArmors>().ToDictionary(x => x.GetType().Name.ToLower(), x => x))
                commands.Add(command.Key, command.Value);

            armors = Serializer.LoadItems<Armor>(ConfigurationManager.AppSettings["allArmorsFile"], "Páncélok");
        }

        public override bool Manage()
        {
            if (armors == null)
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
                    error = !commands[action].Execute(armors, arg);
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
            table.AddRow("detail nameOfTheItem", "Páncél adatainak listázása");

            table.AddRow("", "");
            table.AddRow("back", "Vissza a főmenübe");

            table.Write();

            Console.Write("> ");
        }

        protected override string GetArgsFromCommand(string command)
        {
            if (!command.Contains(" "))
                return "";

            List<string> args = new List<string>(command.Split(" "));

            return String.Join(" ", args.GetRange(1, args.Count - 1));
        }
    }
}
