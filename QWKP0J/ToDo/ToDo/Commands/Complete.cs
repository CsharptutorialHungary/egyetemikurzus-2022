using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ToDo.Commands
{    internal class Complete : ICommand
    {
        public void Execute(IConsole console,string text)
        {
            string vissza = File.ReadAllText(@"D:\csharp_kotprog\egyetemikurzus-2022\QWKP0J\ToDo\ToDo\current.json");
            List<Item> pVissza = JsonSerializer.Deserialize<List<Item>>(vissza);
            pVissza[Convert.ToInt32(text)-1].IsComplete = true;

            string jsonEncoded = JsonSerializer.Serialize(pVissza, new JsonSerializerOptions
            {
                WriteIndented = true,
            });

            File.WriteAllText(@"D:\csharp_kotprog\egyetemikurzus-2022\QWKP0J\ToDo\ToDo\current.json", jsonEncoded);
            foreach (var item in pVissza)
            {
                Console.WriteLine($"{item.Id} | {item.Task} | {item.IsComplete}");
            }
            Console.WriteLine("Feladat készen van");
        }
    }
}
