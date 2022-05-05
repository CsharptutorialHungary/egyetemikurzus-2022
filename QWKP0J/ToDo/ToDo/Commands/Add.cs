using System.Text.Json;

namespace ToDo.Commands
{
    internal class Add : ICommand
    {
        public async void Execute(IConsole console, string text)
        {
            List<Item> pVissza = await Program.FileReader();
            Item elem = new Item(text);

            pVissza.Add(elem);

            string jsonEncoded = JsonSerializer.Serialize(pVissza, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            File.WriteAllText(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\tasklist.json", jsonEncoded);

            Program.BuildConsoleTable();
        }
    }
}
