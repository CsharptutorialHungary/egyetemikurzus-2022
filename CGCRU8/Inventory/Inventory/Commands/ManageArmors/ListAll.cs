using Commands;
using Inventory;
using ConsoleTables;
using Types;
using Controllers;

namespace ArmorCommands
{
    internal class ListAll : IManageArmors
    {
        public bool Execute(params object[] args)
        {
            List<Armor>? armors = args[0] as List<Armor>;

            if (armors == null)
            {
                Logger.Log("(ArmorsController listAll) A kapott argumentum null volt az elvárt érték helyett.");
                return false;
            }

            ItemController<ICommand, Item>.ListItemsInGrid(armors);

            Console.WriteLine("\nNyomj entert a folytatáshoz...");
            Console.ReadLine();

            return true;
        }
    }
}
