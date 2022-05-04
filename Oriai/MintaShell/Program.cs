using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using MintaShell.Commands;

namespace MintaShell
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
#if RELEASE
            commands = from command in commands
                       where command.GetCustomAttribute<LoadableAttribute>() != null
                       select command;
#endif
            foreach (var command in commands)
            {
                yield return (ICommand)Activator.CreateInstance(command);
            }
        }

        static void Main(string[] args)
        {
            Dictionary<string, ICommand> commands
                = LoadCommands()
                .ToDictionary(x => x.GetType().Name.ToLower(), x => x);

            SystemConsole console = new SystemConsole();

            while (true)
            {
                Console.Write("> ");
                string cmd = console.ReadLine().ToLower();
                if (cmd == "exit")
                {
                    break;
                }
                else if (commands.ContainsKey(cmd))
                {
                    commands[cmd].Execute(console);
                }
                else
                {
                    console.WriteLine("Unknown command: {0}", cmd);
                }
            }
        }
    }
}
