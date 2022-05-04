using Commands;
using Inventory;
using Types;
using Controllers;

namespace ItemCommands
{
    internal class ListByCategory : IManageItemsCommand
    {
        public bool Execute(params object[] args)
        {
            if (args == null || args.Length < 1)
            {
                Logger.Log($"(ItemController listByCategory) A kapott argumentumok száma nem volt megfelelő.");
                return false;
            }
            if (args[0] == null || !args[0].GetType().GetGenericArguments()[0].IsSubclassOf(typeof(Item)))
            {
                Logger.Log("(ItemController listByCategory) A kapott argumentum típusa nem volt megfelelő.");
                return false;
            }

            List<Item>? items = new List<Item>((IEnumerable<Item>)args[0]);

            string[] categories = GetItemCategories(items);
            
            foreach(string category in categories)
            {
                var selectedItems = from item in items
                                    where item.Type.Name == category
                                    orderby item.Name
                                    select item;

                Console.WriteLine($"\t{category}");
                ItemController<Item>.ListItemsInGrid(selectedItems.ToList());

                Console.WriteLine("\nNyomj entert a folytatáshoz...");
                Console.ReadLine();
            }

            return true;
        }

        private string[] GetItemCategories(List<Item> items)
        {
            var itemCategories = from item in items
                                 group item.Type.Name by item.Type.Name into categories
                                 select categories;

            List<string> categoriesAsString = new List<string>();
            foreach (var itemCategory in itemCategories)
                categoriesAsString.Add(itemCategory.Key);

            return categoriesAsString.ToArray();
        }
    }
}
