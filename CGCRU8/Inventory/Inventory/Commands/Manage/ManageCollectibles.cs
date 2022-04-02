using Controllers;

namespace Commands
{
    internal class ManageCollectibles : IManageCommand
    {
        public bool Execute()
        {
            return new CollectiblesController().Manage();
        }
    }
}
