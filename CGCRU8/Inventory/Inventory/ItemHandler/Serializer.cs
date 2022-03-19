using Inventory;
using Newtonsoft.Json;

namespace ItemHandler
{
    internal class Serializer<T>
    {
        public static void SaveItems(List<T> ds3Stuff, string destFile)
        {
            File.WriteAllText(destFile, JsonConvert.SerializeObject(ds3Stuff, Formatting.Indented));
        }

        public static List<T>? LoadItems(string srcFile)
        {
            List<T> ds3Stuff = new List<T>();

            Logger.Log("Tárgyak beolvasása elkezdve.");

            try
            {
                ds3Stuff.AddRange(JsonConvert.DeserializeObject<T[]>(srcFile));
            }
            catch (IOException ex)
            {
                Logger.Log("Hiba lépett fel a fájlművelet közben " + ex.Message);
                return null;
            }

            Logger.Log("Tárgyak beolvasása befejeződött.");

            return ds3Stuff;
        }
    }
}
