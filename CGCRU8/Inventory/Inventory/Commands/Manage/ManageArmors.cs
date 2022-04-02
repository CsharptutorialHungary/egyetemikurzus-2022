using Controllers;

namespace Commands
{
    internal class ManageArmors : IManageCommand
    {
        public bool Execute()
        {
            return new ArmorsController().Manage();
        }
    }
}
