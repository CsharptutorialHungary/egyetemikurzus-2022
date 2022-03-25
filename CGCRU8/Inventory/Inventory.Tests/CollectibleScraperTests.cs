using NUnit.Framework;
using ItemHandler;
using System.Reflection;

namespace Inventory.Tests
{
    [TestFixture]
    internal class CollectibleScraperTests
    {
        [Test]
        public void ItemScraper_GetSubPages_Returns_Correct_Links()
        {
            MethodInfo? getSubPagesMethod = typeof(CollectibleScraper).GetMethod("GetSubPages", BindingFlags.NonPublic | BindingFlags.Instance);

            if (getSubPagesMethod == null)
                Assert.Fail("Nincs ilyen nevű metódus");

            string[]? res = getSubPagesMethod.Invoke(new CollectibleScraper(), new object[] { "https://darksouls3.wiki.fextralife.com/Items" }) as string[];

            if (res == null)
                Assert.Fail("Hibás visszatérés");

            Assert.AreEqual(10, res.Length);
            Assert.AreEqual("Key+Items", res[0]);
            Assert.AreEqual("Ashes", res[res.Length - 1]);
        }


        [TestCase("Key+Items", 35, "Dark Sigil", "Blood of the Dark Soul")]
        [TestCase("Multiplayer+Items", 18, "White Sign Soapstone", "Filianore's Spear Ornament")]
        [TestCase("Consumables", 35, "Estus Flask", "Ritual Spear Fragment")]
        [TestCase("Tools", 14, "Darksign", "Twinkling Dragon Torso Stone")]
        [TestCase("Projectiles", 14, "Alluring Skull", "Church Guardian Shiv")]
        [TestCase("Ammunition", 19, "Standard Bolt", "Millwood Greatarrow")]
        [TestCase("Souls", 22, "Fading Soul", "Soul of a Great Champion")]
        [TestCase("Boss+Souls", 24, "Soul of Boreal Valley Vordt", "Soul of Slave Knight Gael")]
        [TestCase("Ore", 27, "Profaned Coal", "Dark Gem")]
        [TestCase("Ashes", 19, "Greirat's Ashes", "Old Woman's Ashes")]
        public void ItemScraper_GetItemsFromCategory_Returns_All_Items_From_Category(string category, int expectedNumber, string firstItem, string lastItem)
        {
            List<Collectible> items = new List<Collectible>();

            MethodInfo? getItemsMethod = typeof(Scraper<CollectibleType, Collectible>).GetMethod("GetItemsFromCategory", BindingFlags.NonPublic | BindingFlags.Instance);

            if (getItemsMethod == null)
                Assert.Fail("Nincs ilyen nevű metódus");

            getItemsMethod.Invoke(new CollectibleScraper(), new object[] { items, category, "https://darksouls3.wiki.fextralife.com/" });

            Assert.AreEqual(expectedNumber, items.Count);
            Assert.AreEqual(firstItem, items[0].Name);
            Assert.AreEqual(lastItem, items[items.Count - 1].Name);
        }
    }
}
