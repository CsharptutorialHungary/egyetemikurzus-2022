using Commands;
using Inventory;
using Types;
using Controllers;

namespace ItemCommands
{
    internal class ListAll : IManageItems
    {
        public bool Execute(params object[] args)
        {
            List<Item>? items = new List<Item>((IEnumerable<Item>)args[0]);

            if (items == null)
            {
                Logger.Log("(ItemController listAll) A kapott argumentum null volt az elvárt érték helyett.");
                return false;
            }

            ItemController<Item>.ListItemsInGrid(items);

            Console.WriteLine("\nNyomj entert a folytatáshoz...");
            Console.ReadLine();

            return true;
        }
    }
}
