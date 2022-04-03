using ConsoleTables;
using Types;
using Inventory;
using ItemHandler;
using System.Configuration;

namespace Controllers
{
    internal abstract class ItemController<ControllerInterface, ItemType> where ItemType : Item
    {
        protected readonly Dictionary<string, ControllerInterface> commands;
        protected readonly List<ItemType>? items;

        public ItemController(string file, string category)
        {
            commands = new Dictionary<string, ControllerInterface>();

            foreach (var command in Controller.LoadCommands<ControllerInterface>().ToDictionary(x => x.GetType().Name.ToLower(), x => x))
                commands.Add(command.Key, command.Value);

            items = Serializer.LoadItems<ItemType>(ConfigurationManager.AppSettings[file], category);
        }

        public abstract bool Manage();

        protected abstract void ConstructConsoleTable();

        protected string GetArgsFromCommand(string command)
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
    }
}
