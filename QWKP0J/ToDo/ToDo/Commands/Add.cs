using System.Text.Json;

namespace ToDo.Commands
{
    internal class Add : ICommand
    {

        static string vissza = File.ReadAllText(@"D:\csharp_kotprog\egyetemikurzus-2022\QWKP0J\ToDo\ToDo\current.json");
        List<Item> pVissza = JsonSerializer.Deserialize<List<Item>>(vissza);
        public void Execute(IConsole console, string text)
        {
            int id = pVissza[pVissza.Count].Id + 1;
            Item elem = new Item(id, text);


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
