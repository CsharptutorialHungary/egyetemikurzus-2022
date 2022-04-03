using Commands;
using Inventory;
using Types;
using Controllers;

namespace ArmorCommands
{
    internal class ListByCategory : IManageArmors
    {
        public bool Execute(params object[] args)
        {
            List<Armor>? armors = args[0] as List<Armor>;

            if (armors == null)
            {
                Logger.Log("(ArmorsController listByCategory) A kapott argumentum null volt az elvárt érték helyett.");
                return false;
            }

            string[] categories = GetArmorCategories(armors);
            
            foreach(string category in categories)
            {
                var selectedArmors = from armor in armors
                                     where armor.Type.Name == category
                                     orderby armor.Name
                                     select armor;

                Console.WriteLine($"\t{category}");
                ItemController<ICommand, Item>.ListItemsInGrid(selectedArmors.ToList());

                Console.WriteLine("\nNyomj entert a folytatáshoz...");
                Console.ReadLine();
            }

            return true;
        }

        private string[] GetArmorCategories(List<Armor> armors)
        {
            var armorCategories = from armor in armors
                                  group armor.Type.Name by armor.Type.Name into categories
                                  select categories;

            List<string> categoriesAsString = new List<string>();
            foreach (var armorCategory in armorCategories)
                categoriesAsString.Add(armorCategory.Key);

            return categoriesAsString.ToArray();
        }
    }
}
