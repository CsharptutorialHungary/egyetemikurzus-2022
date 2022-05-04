using System.Text.Json;

namespace ToDo.Commands
{
    internal class Add : ICommand
    {
        static async Task<List<Item>> ReadFile()
        {
            string vissza = File.ReadAllText(@"D:\csharp_kotprog\egyetemikurzus-2022\QWKP0J\ToDo\ToDo\current.json");
            List<Item> pVissza = JsonSerializer.Deserialize<List<Item>>(vissza);
            return pVissza;
        }
        public async void Execute(IConsole console, string text)
        {
            List<Item> pVissza = await ReadFile();
            Item elem = new Item(text);

            pVissza.Add(elem);

            string jsonEncoded = JsonSerializer.Serialize(pVissza, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            File.WriteAllText(@"D:\csharp_kotprog\egyetemikurzus-2022\QWKP0J\ToDo\ToDo\current.json", jsonEncoded);

            Program.BuildConsoleTable();
        }
    }
}
