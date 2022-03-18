using Inventory;
using Newtonsoft.Json;
using System.Configuration;

namespace ItemHandler
{
    internal class ItemSerializer
    {
        public static void SaveItems(List<Item> allItems)
        {
            File.WriteAllText(ConfigurationManager.AppSettings["allItemsFile"], JsonConvert.SerializeObject(allItems, Formatting.Indented));
        }

        public static List<Item>? LoadItems()
        {
            List<Item> allItems = new List<Item>();

            Logger.Log("Tárgyak beolvasása elkezdve.");

            try
            {
                allItems.AddRange(JsonConvert.DeserializeObject<Item[]>(File.ReadAllText(ConfigurationManager.AppSettings["allItemsFile"])));
            }
            catch (IOException ex)
            {
                Logger.Log("Hiba lépett fel a fájlművelet közben " + ex.Message);
                return null;
            }

            Logger.Log("Tárgyak beolvasása befejeződött.");

            return allItems;
        }
    }
}
