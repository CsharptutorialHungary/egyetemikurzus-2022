using System.Text.Json;

namespace ToDo.Commands
{
    internal class Undo : ICommand
    {
        public async void Execute(IConsole console, string text)
        {
            List<Item> pVissza = await Program.FileReader();

            pVissza[Convert.ToInt32(text) - 1].IsComplete = false;

            string jsonEncoded = JsonSerializer.Serialize(pVissza, new JsonSerializerOptions
            {
                WriteIndented = true,
            });

            File.WriteAllText(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\tasklist.json", jsonEncoded);
            Program.BuildConsoleTable();
        }
    }
}
