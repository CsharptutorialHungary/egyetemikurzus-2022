using Controllers;
using Types;

namespace Commands
{
    internal class ManageRings : IManageCommand
    {
        public bool Execute(params object[] args)
        {
            return new ItemController<Ring>("allRingsFile", "Gyűrű", "Gyűrűk", "Ring").Manage();
        }
    }
}
