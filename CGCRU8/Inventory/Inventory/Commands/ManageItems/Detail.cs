using Commands;
using Inventory;
using Types;

namespace ItemCommands
{
    internal class Detail : IManageItemsCommand
    {
        public bool Execute(params object[] args)
        {
            if(args == null || args.Length < 2)
            {
                Logger.Log($"(ItemController detail) A kapott argumentumok száma nem volt megfelelő.");
                return false;
            }
            else if (!args[0].GetType().GetGenericArguments()[0].IsSubclassOf(typeof(Item)) || args[1] is not string)
            {
                Logger.Log($"(ItemController detail) A kapott argumentumok típusa nem volt megfelelő.");
                return false;
            }

            List<Item>? items = new List<Item>((IEnumerable<Item>)args[0]);
            string? itemName = args[1].ToString();

            IEnumerable<Item> selectedItem = from item in items
                                             where item.Name.ToLower() == itemName
                                             select item;

            if (!selectedItem.Any())
                Console.WriteLine($"Nem található {itemName} nevű tárgy.");
            else
                Console.WriteLine(selectedItem.First().ToString());

            return true;
        }
    }
}
