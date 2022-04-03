using Controllers;

namespace Commands
{
    internal class ManageCollectibles : IManageCommand
    {
        public bool Execute(params object[] args)
        {
            return new CollectiblesController().Manage();
        }
    }
}
