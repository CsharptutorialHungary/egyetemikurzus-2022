using Amoba.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amoba.Tests
{
    [TestClass]
    public class CoordinateTests
    {
        [DataRow(100, -123)]
        [DataRow(-100123, 12)]
        [DataRow(-1123, -12)]
        [DataRow(1123, 2312)]
        [DataRow(0, 0)]
        [DataTestMethod]
        public void Test_X_Y_Constructor(int x, int y)
        {
            var coordinate = new Coordinate(x, y);
            Assert.AreEqual(x, coordinate.X);
            Assert.AreEqual(y, coordinate.Y);
        }

        [DataRow(-1)]
        [DataRow(123123)]
        [DataRow(0)]
        [DataTestMethod]
        public void Test_X_Constructor(int x)
        {
            var coordinate = new Coordinate(x);
            Assert.AreEqual(x, coordinate.X);
            Assert.AreEqual(0, coordinate.Y);
        }

        [TestMethod]
        public void Test_Parameterless_Constructor()
        {
            var coordinate = new Coordinate();
            Assert.AreEqual(0, coordinate.X);
            Assert.AreEqual(0, coordinate.Y);
        }

        [TestMethod]
        public void Test_ToString()
        {
            Coordinate coordinate = new();
            var str = coordinate.ToString();
            Assert.AreEqual("X: 0, Y: 0", str);
        }

        [TestMethod]
        public void Test_ToImmutable()
        {
            Coordinate coordinate = new();
            var recordCord = coordinate.ToImmutable();
            Assert.IsInstanceOfType(recordCord, typeof(RecordCoordinate));
            Assert.AreEqual(0, recordCord.X);
            Assert.AreEqual(0, recordCord.Y);
        }
    }
}