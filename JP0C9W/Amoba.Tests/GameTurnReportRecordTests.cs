using Amoba.Classes;
using Amoba.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Amoba.Tests
{
    [TestClass]
    public class GameTurnReportRecordTests
    {
        private readonly char[][] _testBoard;
        private readonly BoardCell _testMove;

        public GameTurnReportRecordTests()
        {
            _testBoard = new char[5][];
            for (int i = 0; i < _testBoard.Length; i++)
            {
                _testBoard[i] = new char[5];
                for (int j = 0; j < _testBoard[i].Length; j++)
                {
                    _testBoard[i][j] = '#';
                }
            }
            _testBoard[1][0] = 'X';
            _testMove = new BoardCell(0, 1, BoardCellValue.BLACK);
        }

        [TestMethod]
        public void Test_GameTurnReportRecordConstructor()
        {
            var turnReport = new GameTurnReportRecord(1, GameStatus.NOT_FINISHED, _testBoard, _testMove);
            Assert.AreEqual(1, turnReport.TurnIndex);
            Assert.AreEqual(GameStatus.NOT_FINISHED, turnReport.GameStatus);
            Assert.AreEqual(1, turnReport.Move.Y);
            Assert.AreEqual(0, turnReport.Move.X);
            Assert.AreEqual(BoardCellValue.BLACK, turnReport.Move.Value);
            for (int i = 0; i < _testBoard.Length; i++)
            {
                for (int j = 0; j < _testBoard[i].Length; j++)
                {
                    Assert.AreEqual(_testBoard[i][j], turnReport.GameBoardStatus.ElementAt(i)[j]);
                }
            }
        }

        [TestMethod]
        public void Test_ToString_Method()
        {
            var turnReport = new GameTurnReportRecord(1, GameStatus.NOT_FINISHED, _testBoard, _testMove);
            var expectedRes =
                $"Turn: {turnReport.TurnIndex}." +
                "\n" +
                "\n" +
                $"Move: {turnReport.Move}" +
                "\n" +
                "\n" +
                "1  # # # # #\n" +
                "2  X # # # #\n" +
                "3  # # # # #\n" +
                "4  # # # # #\n" +
                "5  # # # # #\n\n";
            Assert.AreEqual(expectedRes, turnReport.ToString());
        }
    }
}