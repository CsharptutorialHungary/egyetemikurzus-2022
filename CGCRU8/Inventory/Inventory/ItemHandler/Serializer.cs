using Inventory;
using Newtonsoft.Json;
using Types;

namespace ItemHandler
{
    internal class Serializer
    {
        public static void SaveItems<T>(List<T> ds3Stuff, string destFile) where T: Item
        {
            File.WriteAllText(destFile, JsonConvert.SerializeObject(ds3Stuff, Formatting.Indented));
        }

        public static List<T>? LoadItems<T>(string srcFile, string type) where T: Item
        {
            List<T> items = new List<T>();

            Logger.Log($"{type} beolvasása elkezdve.");

            try
            {
                items.AddRange(JsonConvert.DeserializeObject<T[]>(File.ReadAllText(srcFile)));
            }
            catch (IOException ex)
            {
                Logger.Log("Hiba lépett fel a fájlművelet közben " + ex.Message);
                return null;
            }

            Logger.Log($"{type} beolvasása befejeződött.");

            return items;
        }
    }
}
