using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amoba.Classes;
using Amoba.Interfaces;
using System.IO;
using System;
using System.Text;

namespace Amoba.Tests
{

    [TestClass]
    public class ConsolePlayerTests
    {
        private StringBuilder ConsoleOutput { get; set; }

        public ConsolePlayerTests()
        {
            ConsoleOutput = new StringBuilder();
        } 

        [TestInitialize]
        public void Setup()
        {
            Console.SetOut(new StringWriter(ConsoleOutput));
            ConsoleOutput.Clear();
        }

        [DataRow(PlayerColor.WHITE)]
        [DataRow(PlayerColor.BLACK)]
        [DataTestMethod]
        public void Test_ConsolePlayer_PlayerColor_Constructor(PlayerColor color)
        {
            var player = new ConsolePlayer(color);
            Assert.IsNotNull(player);
            Assert.AreEqual(color, player.Color);
            Assert.AreEqual(PlayerType.REAL, player.Type);
        }

        [TestMethod]
        public void Test_ConsolePlayer_Parameterless_Constructor()
        {
            var player = new ConsolePlayer();
            Assert.IsNotNull(player);
            Assert.AreEqual(PlayerColor.WHITE, player.Color);
            Assert.AreEqual(PlayerType.REAL, player.Type);
        }

        [DataRow("1","2")]
        [DataRow("1","5")]
        [DataRow("5","1")]
        [DataRow("5","5")]
        [DataRow("03","04")]
        [DataRow("1","1")]
        [DataTestMethod]
        public void Test_GetMove_Method_With_Valid_Input(string row, string col)
        {
            Console.SetIn(new StringReader($"{row}\r\n{col}\r\n"));
            var player = new ConsolePlayer();
            var board = new Board(5);
            player.GetMove(board, null);
            Assert.IsTrue(ConsoleOutput.ToString().Contains("Row:"));
            Assert.IsTrue(ConsoleOutput.ToString().Contains("Column:"));
            Assert.IsFalse(ConsoleOutput.ToString().Contains("is not a valid column index!"));
            Assert.IsFalse(ConsoleOutput.ToString().Contains("is not a valid row index!"));
            Assert.IsFalse(ConsoleOutput.ToString().Contains("is not a valid move!"));
        }

        [DataRow("0", "2", "2")]
        [DataRow("-1", "2", "2")]
        [DataRow("-123", "2", "2")]
        [DataRow("0LULE", "2", "2")]
        [DataRow("xd", "2", "2")]
        [DataRow("0x01", "2", "2")]
        [DataTestMethod]
        public void Test_GetMove_Method_With_Invalid_Row_Index_Input(string invalidRow, string row, string col)
        {
            Console.SetIn(new StringReader($"{invalidRow}\r\n{row}\r\n{col}\r\n"));
            var player = new ConsolePlayer();
            var board = new Board(5);
            player.GetMove(board, null);
            Assert.IsTrue(ConsoleOutput.ToString().Contains("Row:"));
            Assert.IsTrue(ConsoleOutput.ToString().Contains("Column:"));
            Assert.IsTrue(ConsoleOutput.ToString().Contains($"{invalidRow} is not a valid row index!"));
            Assert.IsFalse(ConsoleOutput.ToString().Contains("is not a valid move!"));
        }

        [DataRow("1", "-1", "2", "2")]
        [DataRow("1", "-123", "2", "2")]
        [DataRow("1", "asd", "2", "2")]
        [DataRow("1", "2a", "2", "2")]
        [DataRow("1", "a2", "2", "2")]
        [DataRow("1", "_", "2", "2")]
        [DataTestMethod]
        public void Test_GetMove_Method_With_Invalid_Col_Index_Input(string validRow, string invalidCol, string row, string col)
        {
            Console.SetIn(new StringReader($"{validRow}\r\n{invalidCol}\r\n{row}\r\n{col}\r\n"));
            var player = new ConsolePlayer();
            var board = new Board(5);
            player.GetMove(board, null);
            Assert.IsTrue(ConsoleOutput.ToString().Contains("Row:"));
            Assert.IsTrue(ConsoleOutput.ToString().Contains("Column:"));
            Assert.IsTrue(ConsoleOutput.ToString().Contains($"{invalidCol} is not a valid column index!"));
            Assert.IsFalse(ConsoleOutput.ToString().Contains("is not a valid move!"));
        }

        [DataRow("1", "2", "3", "3")]
        [DataRow("1", "5", "3", "3")]
        [DataRow("5", "1", "3", "3")]
        [DataRow("5", "5", "3", "3")]
        [DataRow("3", "4", "3", "3")]
        [DataRow("1", "1", "3", "3")]
        [DataTestMethod]
        public void Test_GetMove_Method_With_Invalid_Move_Occupied_Cell_Input(string invalidRow, string invalidCol, string row, string col)
        {
            Console.SetIn(new StringReader($"{invalidRow}\r\n{invalidCol}\r\n{row}\r\n{col}\r\n"));
            var player = new ConsolePlayer();
            var board = new Board(5);
            board.SetCell(new BoardCell(int.Parse(invalidCol) - 1, int.Parse(invalidRow) - 1, BoardCellValue.BLACK));
            player.GetMove(board, null);
            Assert.IsTrue(ConsoleOutput.ToString().Contains("Row:"));
            Assert.IsTrue(ConsoleOutput.ToString().Contains("Column:"));
            Assert.IsFalse(ConsoleOutput.ToString().Contains($"is not a valid column index!"));
            Assert.IsFalse(ConsoleOutput.ToString().Contains($"is not a valid row index!"));
            Assert.IsTrue(ConsoleOutput.ToString().Contains($"Row: {invalidRow}, Column: {invalidCol} is not a valid move!"));
        }

        [DataRow("6", "6", "3", "3")]
        [DataRow("5", "6", "3", "3")]
        [DataRow("6", "5", "3", "3")]
        [DataRow("5", "10", "3", "3")]
        [DataRow("123", "123", "3", "3")]
        [DataRow("1", "1123", "3", "3")]
        [DataTestMethod]
        public void Test_GetMove_Method_With_Invalid_Move_Out_Of_Board_Cell_Input(string invalidRow, string invalidCol, string row, string col)
        {
            Console.SetIn(new StringReader($"{invalidRow}\r\n{invalidCol}\r\n{row}\r\n{col}\r\n"));
            var player = new ConsolePlayer();
            var board = new Board(5);
            player.GetMove(board, null);
            Assert.IsTrue(ConsoleOutput.ToString().Contains("Row:"));
            Assert.IsTrue(ConsoleOutput.ToString().Contains("Column:"));
            Assert.IsFalse(ConsoleOutput.ToString().Contains($"is not a valid column index!"));
            Assert.IsFalse(ConsoleOutput.ToString().Contains($"is not a valid row index!"));
            Assert.IsTrue(ConsoleOutput.ToString().Contains($"Row: {invalidRow}, Column: {invalidCol} is not a valid move!"));
        }
    }
}