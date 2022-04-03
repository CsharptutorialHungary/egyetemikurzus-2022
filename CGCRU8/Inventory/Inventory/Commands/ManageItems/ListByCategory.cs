using Commands;
using Inventory;
using Types;
using Controllers;

namespace ItemCommands
{
    internal class ListByCategory : IManageItems
    {
        public bool Execute(params object[] args)
        {
            List<Item>? items = new List<Item>((IEnumerable<Item>)args[0]);

            if (items == null)
            {
                Logger.Log("(ItemController listByCategory) A kapott argumentum null volt az elvárt érték helyett.");
                return false;
            }

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
            foreach (var armorCategory in itemCategories)
                categoriesAsString.Add(armorCategory.Key);

            return categoriesAsString.ToArray();
        }
    }
}
