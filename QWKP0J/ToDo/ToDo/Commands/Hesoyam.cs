using ConsoleTables;

namespace ToDo.Commands
{
    internal class Hesoyam : ICommand
    {
        public void Execute(IConsole console, string text)
        {
            int counter = 1;
            List<Item> items = new List<Item>();
            items.Add(new Item("fogmosás"));
            items.Add(new Item("reggeli készítés"));
            items.Add(new Item("beágyazás"));
            items.Add(new Item("NÓIMI KÍCSI XDDDDD"));
            items[3].IsComplete = true;
            Console.Clear();
            ConsoleTable table = new ConsoleTable("id", "task", "status");
            ConsoleTable table2 = new ConsoleTable("");
            table2.AddRow("daily to-do list");
            table2.AddRow("fosta edition");
            table2.Write(Format.Minimal);
            foreach (var item in items)
            {
                table.AddRow(counter, item.Task, item.IsComplete ? "Kész" : "Folyamatban");
                counter++;
            }
            table.Write();

        }
    }
}
