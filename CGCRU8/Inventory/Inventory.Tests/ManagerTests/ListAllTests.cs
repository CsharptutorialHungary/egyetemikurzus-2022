using NUnit.Framework;
using ItemCommands;
using Types;

namespace Inventory.Tests
{
    [TestFixture]
    internal class ListAllTests
    {
        [Test]
        public void ListAll_Returns_Correct_Value()
        {
            ListAll detail = new ListAll();

            Assert.False(detail.Execute());
            Assert.False(detail.Execute(null));
            Assert.False(detail.Execute(new List<int>()));
            Assert.True(detail.Execute(new List<Armor>()));
        }
    }
}
