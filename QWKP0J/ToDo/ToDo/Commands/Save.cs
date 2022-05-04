using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ToDo.Commands
{
    internal class Save : ICommand
    {
        public void Execute(IConsole console, string text)
        {
            List<Item> items = new List<Item>();
            //TODO try catch, ha üres a lista 
            string vissza = File.ReadAllText(@"D:\csharp_kotprog\egyetemikurzus-2022\QWKP0J\ToDo\ToDo\current.json");
            List<Item> pVissza = JsonSerializer.Deserialize<List<Item>>(vissza);
            items.AddRange(pVissza);
            string saved = File.ReadAllText(@"D:\csharp_kotprog\egyetemikurzus-2022\QWKP0J\ToDo\ToDo\saved.json");
            List<Item> pSaved = JsonSerializer.Deserialize<List<Item>>(saved);
            items.AddRange(pSaved);
            string jsonEncoded = JsonSerializer.Serialize(pVissza, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            File.WriteAllText(@"D:\csharp_kotprog\egyetemikurzus-2022\QWKP0J\ToDo\ToDo\saved.json", jsonEncoded);
        }
    }
}
