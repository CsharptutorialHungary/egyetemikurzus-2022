using System;
using ItemHandler;
using ConsoleTables;
using System.Runtime.CompilerServices;
using System.Configuration;


[assembly: InternalsVisibleTo("Inventory.Tests")]
namespace Inventory
{
    public class Controller
    {
        public static void Main(string[] args)
        {
            try
            {
                new ArmorScraper().ScrapeAllArmorsFromLink();
                return;

                if (!new ItemScraper().ScrapeAllItemsFromLink())
                {
                    Console.WriteLine("A tárgyak létrehozása nem sikerült. További információ a log fájlban.");
                    return;
                }

                List<Item>? allItems = Serializer<Item>.LoadItems(ConfigurationManager.AppSettings["allItemsFile"]);

                if (allItems == null)
                {
                    Console.WriteLine("A tárgyak beolvasása nem sikerült. További információ a log fájlban.");
                    return;
                }

                ConsoleTable table = new ConsoleTable("parancs", "leiras");
                table.AddRow("asd", "asdddddddddddddddd");
                table.AddRow("asdasdasdasda", "asddddddddddddasdasdasddddd");
                table.AddRow("asdasd", "asdddddddddddddfgdfvbcvbcvbdddd");
                table.AddRow("asdasd", "adddddd");
                table.AddRow("kilep", "kilépés a programból");


                while (true)
                {
                    //TODO: console table
                    Console.WriteLine("mit szeretnél csinálni?");

                    table.Write();

                    Console.Write("> ");
                    string? action = Console.ReadLine();

                    if (action == null || action == "" || action == "kilep")
                        break;



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
    }
}