using Amoba.Classes;
using Amoba.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amoba.Tests
{
    [TestClass]
    public class BoardCellTests
    {
        [DataRow(0, 0, BoardCellValue.EMPTY)]
        [DataRow(123, 32423, BoardCellValue.BLACK)]
        [DataRow(-1345, 33, BoardCellValue.WHITE)]
        [DataRow(15, -3, BoardCellValue.WHITE)]
        [DataRow(-35645, -345, BoardCellValue.WHITE)]
        [DataTestMethod]
        public void Test_X_Y_Value_Constructor(int x, int y, BoardCellValue value)
        {
            var cell = new BoardCell(x, y, value);
            Assert.AreEqual(x < 0 ? 0 : x, cell.X);
            Assert.AreEqual(y < 0 ? 0 : y, cell.Y);
            Assert.AreEqual(value, cell.Value);
        }

        [DataRow(0)]
        [DataRow(123)]
        [DataRow(-1345)]
        [DataTestMethod]
        public void Test_X_Constructor(int x)
        {
            var cell = new BoardCell(x);
            Assert.AreEqual(x < 0 ? 0 : x, cell.X);
            Assert.AreEqual(0, cell.Y);
            Assert.AreEqual(BoardCellValue.EMPTY, cell.Value);
        }

        [DataRow(BoardCellValue.BLACK)]
        [DataRow(BoardCellValue.WHITE)]
        [DataRow(BoardCellValue.EMPTY)]
        [DataTestMethod]
        public void Test_Value_Constructor(BoardCellValue value)
        {
            var cell = new BoardCell(value);
            Assert.AreEqual(0, cell.X);
            Assert.AreEqual(0, cell.Y);
            Assert.AreEqual(value, cell.Value);
        }

        [TestMethod]
        public void Test_Parameterless_Constructor()
        {
            var cell = new BoardCell();
            Assert.AreEqual(0, cell.X);
            Assert.AreEqual(0, cell.Y);
            Assert.AreEqual(BoardCellValue.EMPTY, cell.Value);
        }

        [TestMethod]
        public void Test_ToString_Method()
        {
            var cell = new BoardCell();
            var str = cell.ToString();
            Assert.AreEqual($"Color: {BoardCellValue.EMPTY}, Row: {1}, Column: {1}", str);
        }

        [DataRow(1, 2, BoardCellValue.BLACK)]
        [DataRow(11, 23, BoardCellValue.WHITE)]
        [DataRow(111, 233, BoardCellValue.BLACK)]
        [DataRow(1233, 3, BoardCellValue.WHITE)]
        [DataRow(1, 3321, BoardCellValue.EMPTY)]
        [TestMethod]
        public void Test_Copy_Method(int x, int y, BoardCellValue value)
        {
            var cell = new BoardCell(x, y, value);
            var copy = cell.Copy();
            Assert.AreEqual(x, copy.X);
            Assert.AreEqual(y, copy.Y);
            Assert.AreEqual(value, copy.Value);
        }
    }
}