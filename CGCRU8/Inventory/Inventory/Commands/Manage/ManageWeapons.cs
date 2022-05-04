using Controllers;
using Types;

namespace Commands
{
    internal class ManageWeapons : IManageCommand
    {
        public bool Execute(params object[] args)
        {
            return new ItemController<Weapon>("allWeaponsFile", "Fegyver", "Fegyverek", "Weapon").Manage();
        }
    }
}
