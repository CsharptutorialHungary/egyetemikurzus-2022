using Commands;
using Inventory;
using Types;
using Controllers;

namespace ItemCommands
{
    internal class ListAll : IManageItemsCommand
    {
        public bool Execute(params object[] args)
        {
            if (args == null || args.Length < 1)
            {
                Logger.Log($"(ItemController listAll) A kapott argumentumok száma nem volt megfelelő.");
                return false;
            }
            else if (args[0] == null || !args[0].GetType().GetGenericArguments()[0].IsSubclassOf(typeof(Item)))
            {
                Logger.Log("(ItemController listAll) A kapott argumentum típusa nem volt megfelelő.");
                return false;
            }

            List<Item>? items = new List<Item>((IEnumerable<Item>)args[0]);

            ItemController<Item>.ListItemsInGrid(items);

            return true;
        }
    }
}
