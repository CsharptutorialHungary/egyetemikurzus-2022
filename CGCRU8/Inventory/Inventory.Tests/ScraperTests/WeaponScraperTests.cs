using NUnit.Framework;
using ItemHandler;
using System.Reflection;
using Types;

namespace Inventory.Tests
{
    [TestFixture]
    internal class WeaponScraperTests
    {
        [Test]
        public void WeaponScraper_GetSubPages_Returns_Correct_Links()
        {
            MethodInfo? getSubPagesMethod = typeof(WeaponScraper).GetMethod("GetSubPages", BindingFlags.NonPublic | BindingFlags.Instance);

            if (getSubPagesMethod == null)
                Assert.Fail("Nincs ilyen nevű metódus");

            string[]? res = getSubPagesMethod.Invoke(new WeaponScraper(), new object[] { "https://darksouls3.wiki.fextralife.com/Weapons" }) as string[];

            if (res == null)
                Assert.Fail("Hibás visszatérés");

            Assert.AreEqual(24, res.Length);
            Assert.AreEqual("Daggers", res[0]);
            Assert.AreEqual("Sacred+Chimes", res[res.Length - 1]);
        }

        [TestCase("Daggers", 13, "Parrying Dagger", "Aquamarine Dagger")]
        [TestCase("Straight+Swords", 17, "Long Sword", "Ringed Knight Straight Sword")]
        [TestCase("Greatswords", 16, "Claymore", "Gael's Greatsword")]
        [TestCase("Ultra+Greatswords", 11, "Zweihander", "Ringed Knight Paired Greatswords")]
        [TestCase("Curved+Swords", 15, "Scimitar", "Demon's Scar")]
        [TestCase("Katanas", 8, "Darkdrift", "Frayed Blade")]
        [TestCase("Curved+Greatswords", 5, "Murakumo", "Harald Curved Greatsword")]
        [TestCase("Piercing+Swords", 6, "Estoc", "Crow Quills")]
        [TestCase("Axes", 10, "Battle Axe", "Millwood Battle Axe")]
        [TestCase("Greataxes", 7, "Greataxe", "Earth Seeker")]
        [TestCase("Hammers", 8, "Mace", "Warpick")]
        [TestCase("Great+Hammers", 14, "Large Club", "Ledo's Great Hammer")]
        [TestCase("Fist+&+Claws", 6, "Caestus", "Crow Talons")]
        [TestCase("Spears+&+Pikes", 21, "Spear", "Lothric War Banner")]
        [TestCase("Halberds", 11, "Halberd", "Crucifix of the Mad King")]
        [TestCase("Reapers", 4, "Great Scythe", "Friede's Great Scythe")]
        [TestCase("Whips", 5, "Whip", "Rose of Ariandel")]
        [TestCase("Bows", 7, "Short Bow", "White Birch Bow")]
        [TestCase("Greatbows", 3, "Dragonslayer Greatbow", "Millwood Greatbow")]
        [TestCase("Crossbows", 7, "Light Crossbow", "Repeating Crossbow")]
        [TestCase("Staves", 12, "Sorcerer's Staff", "Murky Longstaff")]
        [TestCase("Flames", 3, "Pyromancy Flame", "Demon's Scar")]
        [TestCase("Talismans", 6, "Talisman", "Canvas Talisman")]
        [TestCase("Sacred+Chimes", 7, "Priest's Chime", "Sacred Chime of Filianore")]
        public void WeaponScraper_GetItemsFromCategory_Returns_All_Weapons_From_Category(string category, int expectedNumber, string firstItem, string lastItem)
        {
            List<Weapon> weapons = new List<Weapon>();

            MethodInfo? getWeaponsMethod = typeof(Scraper<WeaponType, Weapon>).GetMethod("GetItemsFromCategory", BindingFlags.NonPublic | BindingFlags.Instance);

            if (getWeaponsMethod == null)
                Assert.Fail("Nincs ilyen nevű metódus");

            getWeaponsMethod.Invoke(new WeaponScraper(), new object[] { weapons, category, "https://darksouls3.wiki.fextralife.com/" });

            Assert.AreEqual(expectedNumber, weapons.Count);
            Assert.AreEqual(firstItem, weapons[0].Name);
            Assert.AreEqual(lastItem, weapons[weapons.Count - 1].Name);
        }
    }
}
