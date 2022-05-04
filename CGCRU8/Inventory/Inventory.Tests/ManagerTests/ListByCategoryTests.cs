using NUnit.Framework;
using ItemCommands;
using Types;
using ItemHandler;
using System.Reflection;

namespace Inventory.Tests
{
    [TestFixture]
    internal class ListByCategoryTests
    {
        [Test]
        public void ListByCategory_GetItemCategories_Test_With_Armors()
        {
            ListByCategory_GetItemCategories_Returns_Correct_Categories<Armor>("all_armors", new string[] { "Helmet", "Chest", "Gauntlet", "Leggings" });
        }

        [Test]
        public void ListByCategory_GetItemCategories_Test_With_Collectibles()
        {
            ListByCategory_GetItemCategories_Returns_Correct_Categories<Collectible>("all_items", new string[] { "Key Item", "Multiplayer Item", "Consumable", "Tool", "Projectile", "Ammunition", "Soul", "Boss Soul", "Ore", "Umbral Ash" });
        }

        [Test]
        public void ListByCategory_GetItemCategories_Test_With_Rings()
        {
            ListByCategory_GetItemCategories_Returns_Correct_Categories<Ring>("all_rings", new string[] { "Ring" });
        }

        [Test]
        public void ListByCategory_GetItemCategories_Test_With_Weapons()
        {
            ListByCategory_GetItemCategories_Returns_Correct_Categories<Weapon>("all_weapons", new string[] { "Dagger", "Straight Sword", "Greatsword", "Ultra Greatrsword", "Curved Sword", "Katana", "Curved Greatsword", "Piercing Sword", "Axe", "Greataxe", "Hammer", "Great Hammer", "Fist & Claw", "Spear & Spike", "Halberd", "Reaper", "Whip", "Bow", "Greatbow", "Crossbow", "Stave", "Flame", "Talisman", "Sacred Chime" });
        }

        private void ListByCategory_GetItemCategories_Returns_Correct_Categories<T>(string fileName, string[] expected) where T : Item
        {
            List<Item> items = new List<Item>(Serializer.LoadItems<T>($"../../../../{fileName}.json", ""));
            MethodInfo? getItemCategoriesMethod = typeof(ListByCategory).GetMethod("GetItemCategories", BindingFlags.NonPublic | BindingFlags.Instance);

            if (getItemCategoriesMethod == null)
                Assert.Fail("Nincs ilyen nevű metódus");

            string[]? res = getItemCategoriesMethod.Invoke(new ListByCategory(), new object[] { items }) as string[];

            Assert.AreEqual(expected, res);
        }
    }
}
