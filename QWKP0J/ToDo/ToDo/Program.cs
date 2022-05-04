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
                    commands[cmd[0]].Execute(console, cmd[1]);
                }
                else
                {
                    console.WriteLine("Unknown command: {0}", cmd[0]);
                }
            }
        }

        public static void BuildConsoleTable()
        {
            Console.Clear();
            ConsoleTable commandTable = new ConsoleTable("Add", "Complete", "Delete", "Exit");
            commandTable.Write(Format.Default);

            string loadList = File.ReadAllText($@"D:\csharp_kotprog\egyetemikurzus-2022\QWKP0J\ToDo\ToDo\current.json");
            List<Item> pLoadList = JsonSerializer.Deserialize<List<Item>>(loadList);

            ConsoleTable table = new ConsoleTable("id", "task", "status");
            foreach (var item in pLoadList)
            {
                table.AddRow(item.Id, item.Task, item.IsComplete);
            }
            table.Write(Format.Default);
        }
    }
}
