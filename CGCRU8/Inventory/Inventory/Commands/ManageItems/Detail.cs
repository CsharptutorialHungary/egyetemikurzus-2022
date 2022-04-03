using Commands;
using Inventory;
using Types;

namespace ItemCommands
{
    internal class Detail : IManageItems
    {
        public bool Execute(params object[] args)
        {
            List<Item>? items = new List<Item>((IEnumerable<Item>)args[0]);
            string? itemName = args[1].ToString();

            if(items == null || itemName == null)
            {
                Logger.Log($"(ItemController detail[{itemName}]) A kapott argumentum null volt az elvárt érték helyett.");
                return false;
            }

            IEnumerable<Item> selectedItem = from item in items
                                              where item.Name.ToLower() == itemName
                                              select item;

            if(!selectedItem.Any())
                Console.WriteLine($"Nem található {itemName} nevű tárgy.");
            else
                Console.WriteLine(selectedItem.First().ToString());

            Console.WriteLine("\nNyomj entert a folytatáshoz...");
            Console.ReadLine();

            return true;
        }
    }
}
