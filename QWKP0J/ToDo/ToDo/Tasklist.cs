using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    internal class Tasklist
    {

        private void DisplayItemInfo(Item item)
        {
            Console.WriteLine($"{ item.Id}, { item.Task}, {item.IsComplete}");
        }

        private void ListItems(List<Item> items)
        {
            foreach (var item in items)
                DisplayItemInfo(item);
        }
        private List<Item> itemlist { get; set; } = new List<Item>();
         public void AddItem(Item item)
        {
            itemlist.Add(item);
        }

        public void Display(int number)
        {
            var item = itemlist.FirstOrDefault(c => c.Id == number);
            if (item != null)
            {
                Console.WriteLine("nincs");
            }
            else
            {
                DisplayItemInfo(item);
            }
        }
        public void DisplayAll()
        {
            ListItems(itemlist);
        }

    }
}
