using Controllers;

namespace Commands
{
    internal class ManageRings : IManageCommand
    {
        public bool Execute(params object[] args)
        {
            return new RingController().Manage();
        }
    }
}
