using Commands;
using Inventory;
using Types;

namespace ArmorCommands
{
    internal class Detail : IManageArmors
    {
        public bool Execute(params object[] args)
        {
            List<Armor>? armors = args[0] as List<Armor>;
            string? armorName = args[1].ToString();

            if(armors == null || armorName == null)
            {
                Logger.Log("(ArmorsController detail) A kapott argumentum null volt az elvárt érték helyett.");
                return false;
            }

            IEnumerable<Armor> selectedArmor = from armor in armors
                                               where armor.Name.ToLower() == armorName
                                               select armor;

            if(!selectedArmor.Any())
                Console.WriteLine($"Nem található {armorName} nevű páncél!");
            else
            {
                Armor armor = selectedArmor.First();

                Console.WriteLine(armor.ToString());
            }

            Console.WriteLine("\nNyomj entert a folytatáshoz...");
            Console.ReadLine();

            return true;
        }
    }
}
