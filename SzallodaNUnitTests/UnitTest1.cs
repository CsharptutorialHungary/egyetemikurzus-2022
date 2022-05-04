using NUnit.Framework;
using Szalloda;
using Szalloda.Data;

namespace SzallodaNUnitTests
{
    [TestFixture]
    public class Tests
    {
        private Guest guest;

        [SetUp]
        public void Setup()
        {
            guest = new Guest();

        }

        [Test]
        public void GuestAgeBelowEighteenTest()
        {

            guest.Age = -7;
            Assert.AreEqual(18, guest.Age);
        }

        [Test]
        public void GuestAgeAboveMaxTest()
        {
            guest.Age = 100;
            Assert.AreEqual(99, guest.Age);
        }

        [Test]
        public void GuestAgeBetweenValidInputTest()
        {
            guest.Age = 31;
            Assert.AreEqual(31, guest.Age);
        }

        [Test]
        public void GuestChildrenBelowZeroTest()
        {
            guest.Children = -1;
            Assert.AreEqual(0, guest.Children);
        }

        [Test]
        public void GuestAdultsBelowOneTest()
        {
            guest.Adults = 0;
            Assert.AreEqual(1, guest.Adults);
        }

        [Test]
        public void GuestDepartureDateBeforeArrivalDateTest()
        {
            guest.DepartureDate = new System.DateTime(2022, 06, 04);
            guest.ArrivalDate = new System.DateTime(2022, 06, 05);
            Assert.GreaterOrEqual(new System.DateTime(2022, 06, 06), guest.ArrivalDate);
        }

    }
}