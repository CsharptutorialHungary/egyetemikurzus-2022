using Commands;
using ConsoleTables;
using System.Runtime.CompilerServices;
using System.Configuration;
using System.Reflection;
using System.Collections.Generic;

[assembly: InternalsVisibleTo("Inventory.Tests")]
namespace Inventory
{
    public class Controller
    {
        public static void Main(string[] args)
        {
            try
            {
                Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

                foreach(var command in LoadCommands<IGetCommand>().ToDictionary(x => x.GetType().Name.ToLower(), x => x))
                    commands.Add(command.Key, command.Value);

                foreach (var command in LoadCommands<IManageCommand>().ToDictionary(x => x.GetType().Name.ToLower(), x => x))
                    commands.Add(command.Key, command.Value);

                while (true)
                {
                    ConsoleTable table = new ConsoleTable("Parancs", "Leírás");
                    Console.WriteLine("\n\tMit szeretnél csinálni?");

                    if(MissingFile("allItemsFile", "allWeaponsFile", "allArmorsFile", "allRingsFile"))
                        table.AddRow("GetAll", "Minden megszerzése (tárgyak, fegyverek, páncélok, gyűrűk)");

                    table.AddRow($"{MissingFileText("allItemsFile", true)}Collectibles", $"Tárgyak {MissingFileText("allItemsFile")}");
                    table.AddRow($"{MissingFileText("allWeaponsFile", true)}Weapons", $"Fegyverek {MissingFileText("allWeaponsFile")}");
                    table.AddRow($"{MissingFileText("allArmorsFile", true)}Armors", $"Páncélok {MissingFileText("allArmorsFile")}");
                    table.AddRow($"{MissingFileText("allRingsFile", true)}Rings", $"Gyűrűk {MissingFileText("allRingsFile")}");

                    table.AddRow("", "");
                    if(!MissingFile("allItemsFile", "allWeaponsFile", "allArmorsFile", "allRingsFile"))
                        table.AddRow("eszkoztar", "Eszköztár megnyitása");


                    table.AddRow("", "");
                    table.AddRow("close", "Kilépés a programból");

                    table.Write();

                    Console.Write("> ");
                    string? action = Console.ReadLine();

                    if (string.IsNullOrEmpty(action))
                        break;

                    action = action.ToLower();

                    if (action == "close")
                        break;

                    Console.WriteLine("\n\n\n\n");

                    bool error = false;
                    if (commands.ContainsKey(action))
                        error = !commands[action].Execute();
                    else
                        Console.WriteLine($"Ismeretlen parancs: {action}!");

                    if(error)
                    {
                        Console.WriteLine($"Hiba lépett fel a(z) {action} parancs futtatása közben. Bővebb információ a log fájlban.");
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ismeretlen hiba lépett fel. További információ a log fájlban.");
                Logger.Log("Hiba: " + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                Logger.Log("\n\n");
            }
        }

        private static bool MissingFile(params string[] files)
        {
            foreach (string file in files)
                if (!File.Exists(ConfigurationManager.AppSettings[file]))
                    return true;

            return false;
        }

        private static string MissingFileText(string fileName, bool command = false)
        {
            if (MissingFile(fileName))
                return command ? "Get" : "megszerzése a wikipédiáról";
            else
                return command ? "Manage" : "kezelése";
        }

        public static IEnumerable<CommandType> LoadCommands<CommandType>()
        {
            var commands = from command in Assembly.GetExecutingAssembly().GetTypes()
                           where typeof(CommandType).IsAssignableFrom(command) && !command.IsAbstract
                           select command;

            foreach (var command in commands)
                yield return (CommandType)Activator.CreateInstance(command);
        }
    }
}