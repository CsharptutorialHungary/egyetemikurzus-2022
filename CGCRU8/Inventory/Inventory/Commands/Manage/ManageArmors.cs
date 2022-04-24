using Controllers;
using Types;

namespace Commands
{
    internal class ManageArmors : IManageCommand
    {
        public bool Execute(params object[] args)
        {
            return new ItemController<Armor>("allArmorsFile", "Páncél", "Páncélok", "Armor").Manage();
        }
    }
}
