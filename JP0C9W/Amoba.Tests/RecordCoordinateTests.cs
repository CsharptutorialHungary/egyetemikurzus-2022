using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amoba.Classes;

namespace Amoba.Tests
{
    [TestClass]
    public class RecordCoordinateTests
    {
        [DataRow(111, -666)]
        [DataRow(-4235, 34)]
        [DataRow(-1123, -12)]
        [DataRow(234, 456452)]
        [DataRow(0, 0)]
        [DataTestMethod]
        public void Test_X_Y_Constructor(int x, int y)
        {
            var cord = new RecordCoordinate(x, y);
            Assert.AreEqual(x, cord.X);
            Assert.AreEqual(y, cord.Y);
        }

        [DataRow(111)]
        [DataRow(-4235)]
        [DataRow(0)]
        [DataTestMethod]
        public void Test_X_Constructor(int x)
        {
            var cord = new RecordCoordinate(x);
            Assert.AreEqual(x, cord.X);
            Assert.AreEqual(0, cord.Y);
        }

        [TestMethod]
        public void Test_Parameterless_Constructor()
        {
            var cord = new RecordCoordinate();
            Assert.AreEqual(0, cord.X);
            Assert.AreEqual(0, cord.Y);
        }

        [TestMethod]
        public void Test_ToString()
        {
            Coordinate coordinate = new();
            var str = coordinate.ToString();
            Assert.AreEqual("X: 0, Y: 0", str);
        }
    }
}