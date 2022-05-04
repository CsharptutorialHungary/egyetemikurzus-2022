using NUnit.Framework;
using ItemHandler;
using System.Reflection;
using Types;

namespace Inventory.Tests
{
    [TestFixture]
    internal class ArmorScraperTests
    {
        [Test]
        public void ArmorScraper_GetSubPages_Returns_Correct_Links()
        {
            MethodInfo? getSubPagesMethod = typeof(ArmorScraper).GetMethod("GetSubPages", BindingFlags.NonPublic | BindingFlags.Instance);

            if (getSubPagesMethod == null)
                Assert.Fail("Nincs ilyen nevű metódus");

            string[]? res = getSubPagesMethod.Invoke(new ArmorScraper(), new object[] { "https://darksouls3.wiki.fextralife.com/Armor" }) as string[];

            if (res == null)
                Assert.Fail("Hibás visszatérés");

            Assert.AreEqual(4, res.Length);
            Assert.AreEqual("Helms", res[0]);
            Assert.AreEqual("Chest+Armor", res[1]);
            Assert.AreEqual("Gauntlets", res[2]);
            Assert.AreEqual("Leggings", res[3]);
        }


        [TestCase("Helms", 93, "Standard Helm", "White Preacher Head")]
        [TestCase("Chest+Armor", 93, "Hard Leather Armor", "Desert Pyromancer Garb")]
        [TestCase("Gauntlets", 85, "Hard Leather Gauntlets", "Desert Pyromancer Gloves")]
        [TestCase("Leggings", 90, "Hard Leather Boots", "Loincloth (The Ringed City)")]
        public void ItemScraper_GetItemsFromCategory_Returns_All_Items_From_Category(string category, int expectedNumber, string firstItem, string lastItem)
        {
            List<Armor> armors = new List<Armor>();

            MethodInfo? getItemsMethod = typeof(Scraper<ArmorType, Armor>).GetMethod("GetItemsFromCategory", BindingFlags.NonPublic | BindingFlags.Instance);

            if (getItemsMethod == null)
                Assert.Fail("Nincs ilyen nevű metódus");

            getItemsMethod.Invoke(new ArmorScraper(), new object[] { armors, category, "https://darksouls3.wiki.fextralife.com/" });

            Assert.AreEqual(expectedNumber, armors.Count);
            Assert.AreEqual(firstItem, armors[0].Name);
            Assert.AreEqual(lastItem, armors[armors.Count - 1].Name);
        }
    }
}
