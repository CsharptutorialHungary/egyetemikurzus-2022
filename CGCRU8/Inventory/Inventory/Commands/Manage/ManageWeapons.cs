using Controllers;

namespace Commands
{
    internal class ManageWeapons : IManageCommand
    {
        public bool Execute()
        {
            return new WeaponsController().Manage();
        }
    }
}
