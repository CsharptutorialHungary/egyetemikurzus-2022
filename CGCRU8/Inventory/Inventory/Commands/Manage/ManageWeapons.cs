using Controllers;

namespace Commands
{
    internal class ManageWeapons : IManageCommand
    {
        public bool Execute(params object[] args)
        {
            return new WeaponController().Manage();
        }
    }
}
