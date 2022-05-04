using System.Text.Json;

namespace ToDo.Commands
{
    internal class Add : ICommand
    {
        int id = 1;

        static string vissza = File.ReadAllText(@"D:\csharp_kotprog\egyetemikurzus-2022\QWKP0J\ToDo\ToDo\current.json");
        List<Item> pVissza = JsonSerializer.Deserialize<List<Item>>(vissza);


        public void Execute(IConsole console, string text)
        {

            Item elem = new Item(id, text);
            id++;

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
