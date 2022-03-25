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
                while (true)
                {
                    ConsoleTable table = new ConsoleTable("Parancs", "Leírás");
                    Console.WriteLine("\n\tMit szeretnél csinálni?");

                    if(MissingFile("allItemsFile", "allWeaponsFile", "allArmorsFile", "allRingsFile"))
                        table.AddRow("minden_megszerzese", "Minden megszerzése (tárgyak, fegyverek, páncélok, gyűrűk)");

                    table.AddRow("targyak_" + MissingFileText("allItemsFile", true), "Tárgyak " + MissingFileText("allItemsFile"));
                    table.AddRow("fegyverek_" + MissingFileText("allWeaponsFile", true), "Fegyverek " + MissingFileText("allWeaponsFile"));
                    table.AddRow("pancelok_" + MissingFileText("allArmorsFile", true), "Páncélok " + MissingFileText("allArmorsFile"));
                    table.AddRow("gyuruk_" + MissingFileText("allRingsFile", true), "Gyűrűk " + MissingFileText("allRingsFile"));


                    table.AddRow("", "");
                    if(!MissingFile("allItemsFile", "allWeaponsFile", "allArmorsFile", "allRingsFile"))
                        table.AddRow("eszkoztar", "Eszköztár megnyitása");


                    table.AddRow("", "");
                    table.AddRow("kilep", "Kilépés a programból");

                    table.Write();

                    Console.Write("> ");
                    string? action = Console.ReadLine();

                    if (action == null || action == "" || action == "kilep")
                        break;

                    DoSomething(action);

                    Console.WriteLine("\n\n\n\n");
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
                return command ? "megszerzese" : "megszerzése a wikipédiáról";
            else
                return command ? "kezelese" : "kezelése";
        }

        private static void DoSomething(string command)
        {
            switch (command)
            {
                case "minden_megszerzese":
                {
                    new CollectibleScraper().ScrapeAllItemsFromLink();
                    new WeaponScraper().ScrapeAllItemsFromLink();
                    new ArmorScraper().ScrapeAllItemsFromLink();
                    new RingScraper().ScrapeAllItemsFromLink();
                    break;
                }
                case "targyak_megszerzese":
                    new CollectibleScraper().ScrapeAllItemsFromLink();
                    break;

                default:
                    Console.WriteLine("Ismeretlen parancs!");
                    break;
            }
        }
    }
}