using Controllers;
using Types;

namespace Commands
{
    internal class ManageCollectibles : IManageCommand
    {
        public bool Execute(params object[] args)
        {
            return new ItemController<Collectible>("allItemsFile", "Tárgy", "Tárgyak", "Collectible").Manage();
        }
    }
}
