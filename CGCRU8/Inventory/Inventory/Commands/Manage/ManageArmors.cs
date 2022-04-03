using Controllers;

namespace Commands
{
    internal class ManageArmors : IManageCommand
    {
        public bool Execute(params object[] args)
        {
            return new ArmorController().Manage();
        }
    }
}
