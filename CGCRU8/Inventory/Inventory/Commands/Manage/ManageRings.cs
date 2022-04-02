using Controllers;

namespace Commands
{
    internal class ManageRings : IManageCommand
    {
        public bool Execute()
        {
            return new RingsController().Manage();
        }
    }
}
