using System;
using System.IO;
using System.Text.Json;

namespace ToDo.Commands
{    internal class List : ICommand
    {
        public void Execute(IConsole console,string text)
        {
            string vissza = File.ReadAllText($@"D:\csharp_kotprog\egyetemikurzus-2022\QWKP0J\ToDo\ToDo\{text}.json");
            List<Item> pVissza = JsonSerializer.Deserialize<List<Item>>(vissza);

            foreach (var item in pVissza)
            {
                Console.WriteLine($"{item.Id} | {item.Task} | {item.IsComplete}");
            }
        }
    }
}
