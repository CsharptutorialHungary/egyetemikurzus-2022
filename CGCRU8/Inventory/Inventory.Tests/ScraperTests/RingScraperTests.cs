using NUnit.Framework;
using ItemHandler;
using System.Reflection;
using Types;

namespace Inventory.Tests
{
    [TestFixture]
    internal class RingScraperTests
    {
        [Test]
        public void RingScraper_GetRingsFromPage_Returns_All_Rings()
        {
            List<Ring> rings = new List<Ring>();

            MethodInfo? getRingsMethod = typeof(Scraper<RingType, Ring>).GetMethod("GetItemsFromCategory", BindingFlags.NonPublic | BindingFlags.Instance);

            if (getRingsMethod == null)
                Assert.Fail("Nincs ilyen nevű metódus");

            getRingsMethod.Invoke(new RingScraper(), new object[] { rings, "Rings", "https://darksouls3.wiki.fextralife.com/" });

            Assert.AreEqual(71, rings.Count);
            Assert.AreEqual("Life Ring", rings[0].Name);
            Assert.AreEqual("Chillbite Ring", rings[rings.Count - 1].Name);
        }
    }
}
