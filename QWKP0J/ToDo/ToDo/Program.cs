using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Windows.Input;
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
            Console.WriteLine("[Add {task}]");
            Console.WriteLine("[List {saved | current}]");
            Console.WriteLine("[Complete {id}]");
            Console.WriteLine("[Save]");
            Console.WriteLine("[Delete {id}]");
            Console.WriteLine("[Exit]");
            




            Dictionary<string, ICommand> commands
                = LoadCommands()
                .ToDictionary(x => x.GetType().Name.ToLower(), x => x);

            SystemConsole console = new SystemConsole();

            while (true)
            {
                Console.Write("> ");
                string input = console.ReadLine().ToLower();
                string[] cmd = input.Split(' ',2);
                if (cmd[0] == "exit")
                {
                    break;
                }
                else if (commands.ContainsKey(cmd[0]) && cmd.Length!=1)
                { 
                    commands[cmd[0]].Execute(console, cmd[1]);
                }
                else
                {
                    console.WriteLine("Unknown command: {0}", cmd[0]);
                }
            }




























           /* Tasklist item = new Tasklist();
            while (true)
            {
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "add":
                        Console.WriteLine("Task to do:");
                        string task = Console.ReadLine();

                        Item newItem = new Item(task);
                        item.AddItem(newItem);
                        Console.WriteLine("Added");
                        break;
                    case "complete":
                        
                        break;
                    case "delete":
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("valid command pls");
                        break;

                }
            }*/
            
        }
    }
}
