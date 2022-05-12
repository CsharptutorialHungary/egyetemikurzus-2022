using Amoba.Classes;
using Amoba.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Amoba.Tests
{
    [TestClass]
    public class RandomPlayerTests
    {
        [TestMethod]
        public void Test_Static_Shuffle_Collection()
        {
            IList<char> list = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n' };
            var expected = String.Join(", ", list.ToArray());
            RandomPlayer.ShuffleCollection(ref list);
            var result = String.Join(", ", list.ToArray());
            Assert.AreNotEqual(expected, result);
        }

        [DataRow(PlayerColor.WHITE)]
        [DataRow(PlayerColor.BLACK)]
        [DataTestMethod]
        public void Test_RandomPlayer_Color_Board_Constructor(PlayerColor color)
        {
            var board = new Board(5);
            var player = new RandomPlayer(color, board);
            Assert.AreEqual(player.Color, color);
            PropertyInfo? propInfo = typeof(RandomPlayer).GetProperty("FreeCells", BindingFlags.NonPublic | BindingFlags.Instance);
            if (propInfo != null)
            {
                var freeCells = propInfo.GetValue(player);
                if (propInfo.GetValue(player) is IList<IBoardCell> result)
                {
                    Assert.IsTrue(result.All(cell => cell.Value == BoardCellValue.EMPTY));
                }
                else
                {
                    Assert.Fail("No FreeCells property!");
                }
            }
        }

        [DataRow(PlayerColor.WHITE)]
        [DataRow(PlayerColor.BLACK)]
        [DataTestMethod]
        public void Test_GetMove_No_Free_Cells(PlayerColor color)
        {
            var board = new Board(5);
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    board.SetCell(new BoardCell(j, i, color == PlayerColor.WHITE ? BoardCellValue.WHITE : BoardCellValue.BLACK));
                }
            }
            var player = new RandomPlayer(color, board);
            var excpetion = Assert.ThrowsException<Exception>(() => player.GetMove(board, null));
            Assert.AreEqual("Board is full!", excpetion.Message);
        }

        [DataRow(PlayerColor.WHITE)]
        [DataRow(PlayerColor.BLACK)]
        [DataTestMethod]
        public void Test_GetMove_Valid(PlayerColor color)
        {
            var board = new Board(5);
            var prevMove = new BoardCell(1, 1, color == PlayerColor.WHITE ? BoardCellValue.BLACK : BoardCellValue.WHITE);
            var player = new RandomPlayer(color, board);
            var move = player.GetMove(board, prevMove);
            Assert.IsNotNull(move);
            string expected = $"{move.Y}{move.X}";
            string result = $"{prevMove.Y}{prevMove.X}";
            Assert.AreNotEqual(expected, result);
            Assert.AreNotEqual(prevMove.Value, move.Value);
        }

        [DataRow(PlayerColor.WHITE)]
        [DataRow(PlayerColor.BLACK)]
        [DataTestMethod]
        public void Test_GetMove_PrevMove_Not_In_FreeCells(PlayerColor color)
        {
            var board = new Board(5);
            var prevMove = new BoardCell(2, 1, color == PlayerColor.WHITE ? BoardCellValue.BLACK : BoardCellValue.WHITE);
            board.SetCell(prevMove);
            var player = new RandomPlayer(color, board);
            var excpetion = Assert.ThrowsException<InvalidOperationException>(() => player.GetMove(board, prevMove));
        }
    }
}