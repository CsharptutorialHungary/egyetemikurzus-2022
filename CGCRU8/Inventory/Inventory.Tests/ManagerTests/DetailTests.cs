using NUnit.Framework;
using ItemCommands;
using Types;
using ItemHandler;

namespace Inventory.Tests
{
    [TestFixture]
    internal class DetailTests
    {
        [Test]
        public void Detail_Returns_Correct_Value()
        {
            Detail detail = new Detail();

            Assert.False(detail.Execute());
            Assert.False(detail.Execute(5));
            Assert.False(detail.Execute(new List<Armor>(), null));
            Assert.False(detail.Execute(new List<int>(), "szoveg"));
            Assert.True(detail.Execute(new List<Armor>(), "fegyver"));
        }

        [Test]
        public void Detail_Finds_Item_Correctly()
        {
            List<Ring> rings = Serializer.LoadItems<Ring>("../../../../all_rings.json", "Gyűrűk");
            Detail detail = new Detail();

            var consolOutChannel = Console.Out;

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                detail.Execute(rings, "life ring");
                Assert.AreEqual(rings[0].ToString() + Environment.NewLine, sw.ToString());
            }

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                detail.Execute(rings, "asd");
                Assert.AreEqual("Nem található asd nevű tárgy." + Environment.NewLine, sw.ToString());

            }

            Console.SetOut(consolOutChannel);
        }
    }
}
