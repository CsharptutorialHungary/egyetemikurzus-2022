using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ToDo.Commands
{
    internal class ADd : ICommand
    {
        int id = 0;
        List<Item> list = new List<Item>();

        public void Execute(IConsole console,string text)
        {
            id++;
            Item elem = new Item(id, text);
            list.Add(elem);


            string jsonEncoded = JsonSerializer.Serialize(list, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            File.WriteAllText(@"D:\csharp_kotprog\egyetemikurzus-2022\QWKP0J\ToDo\ToDo\current.json", jsonEncoded);

            console.WriteLine("Hozzáadva a listához");
        }
    }
}
