using ConsoleTables;
using System.Reflection;
using System.Text.Json;
using ToDo.Commands;
namespace ToDo
{
    internal static class Program
    {

        static IEnumerable<ICommand> LoadCommands()
        {
            var current = Assembly.GetExecutingAssembly();
            var commands = from command in current.GetTypes()
                           where
                           typeof(ICommand).IsAssignableFrom(command)
                           && !command.IsAbstract
                           select command;

            foreach (var command in commands)
            {
                yield return (ICommand)Activator.CreateInstance(command);
            }
        }
        static void Main(string[] args)
        {

            BuildConsoleTable();

            Dictionary<string, ICommand> commands
                = LoadCommands()
                .ToDictionary(x => x.GetType().Name.ToLower(), x => x);

            SystemConsole console = new SystemConsole();

            while (true)
            {
                Console.Write("> ");
                string input = console.ReadLine().ToLower();
                string[] cmd = input.Split(' ', 2);
                if (cmd[0] == "exit")
                {
                    break;
                }
                else if (commands.ContainsKey(cmd[0]) && cmd.Length != 1)
                {
                    commands[cmd[0]].Execute(console, cmd.Length == 1 ? " " : cmd[1]); //csöves megoldás de működik
                }
                else
                {
                    console.WriteLine("Unknown command: {0}", cmd[0]);
                }
            }
        }

        public static async void BuildConsoleTable()
        {
            List<Item> pLoadList = null;
            int counter = 1;
            Console.Clear();

            ConsoleTable commandTable = new ConsoleTable("Add <feladat>", "Finish <id>", "Undo <id>", "Delete <id>", "Exit");
            commandTable.AddRow("Feladat hozzáadása", "Státusz készre állítása", "Státusz visszallítása", "Feladat törlése", "Kilépés");
            commandTable.Write();

            try
            {
                pLoadList = await FileReader();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Hiányzik a json fájl.");
                Environment.Exit(1);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Baj van a json-nel.");
                Environment.Exit(1);
            }

            if (pLoadList != null)
            {
                ConsoleTable table = new ConsoleTable("id", "feladatok", "státusz");

                foreach (var item in pLoadList)
                {
                    table.AddRow(counter, item.Task, item.IsComplete ? "Kész" : "Folyamatban");
                    counter++;
                }
                table.Write();
            }
        }
        public static async Task<List<Item>> FileReader()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\tasklist.json";
            string loadList = File.ReadAllText(path);
            List<Item> pLoadList = JsonSerializer.Deserialize<List<Item>>(loadList);

            return pLoadList;
        }
    }
}
