using System;
using System.Diagnostics;
using ItemHandler;
using ConsoleTables;

namespace Inventory
{
    public class Controller
    {
        public static void Main(string[] args)
        {
            try
            {
                if (!new ItemScraper().ScrapeAllItemsFromLink())
                {
                    Console.WriteLine("A tárgyak létrehozása nem sikerült. További információ a log fájlban.");
                    return;
                }

                List<Item>? allItems = ItemSerializer.LoadItems();

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
                Logger.Log("Hiba: " + ex.StackTrace);
            }
            finally
            {
                Logger.Log("\n\n");
            }
        }
    }
}