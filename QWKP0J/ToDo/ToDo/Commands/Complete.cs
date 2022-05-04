using System.Text.Json;

namespace ToDo.Commands
{
    internal class Complete : ICommand
    {
        public void Execute(IConsole console, string text)
        {
            string vissza = File.ReadAllText(@"D:\csharp_kotprog\egyetemikurzus-2022\QWKP0J\ToDo\ToDo\current.json");
            List<Item> pVissza = JsonSerializer.Deserialize<List<Item>>(vissza);
            pVissza[Convert.ToInt32(text) - 1].IsComplete = true;

            string jsonEncoded = JsonSerializer.Serialize(pVissza, new JsonSerializerOptions
            {
                WriteIndented = true,
            });

            File.WriteAllText(@"D:\csharp_kotprog\egyetemikurzus-2022\QWKP0J\ToDo\ToDo\current.json", jsonEncoded);
            Program.BuildConsoleTable();

        }
    }
}
