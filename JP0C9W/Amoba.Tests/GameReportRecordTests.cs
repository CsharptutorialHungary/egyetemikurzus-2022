using Amoba.Classes;
using Amoba.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Amoba.Tests
{
    [TestClass]
    public class GameReportRecordTests
    {
        private StringBuilder ConsoleOutput { get; set; }
        private readonly List<GameTurnReportRecord> _testTurnReports;
        private readonly GameReportRecord _testGameReport;

        public GameReportRecordTests()
        {
            var board = new char[5][];
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = new char[5];
                for (int j = 0; j < board[i].Length; j++)
                {
                    board[i][j] = '#';
                }
            }
            board[1][0] = 'O';
            var ehiteMove = new BoardCell(0, 1, BoardCellValue.WHITE);
            _testTurnReports = new();
            _testTurnReports.Add(new GameTurnReportRecord(1, GameStatus.NOT_FINISHED, (char[][])board.Clone(), ehiteMove));
            board[3][2] = 'X';
            var blackMove = new BoardCell(3, 2, BoardCellValue.BLACK);
            _testTurnReports.Add(new GameTurnReportRecord(1, GameStatus.BLACK_WON, (char[][])board.Clone(), blackMove));
            _testGameReport = new GameReportRecord(GameMode.REAL_VS_REAL, _testTurnReports);
            ConsoleOutput = new StringBuilder();
        }

        [TestInitialize]
        public void Setup()
        {
            Console.SetOut(new StringWriter(ConsoleOutput));
            ConsoleOutput.Clear();
        }

        [TestMethod]
        public void Test_GameReportRecord_GameMode_Reports_Constructor()
        {
            var gameReport = new GameReportRecord(GameMode.REAL_VS_REAL, _testTurnReports);
            Assert.AreEqual(GameMode.REAL_VS_REAL, gameReport.GameMode);
            Assert.AreEqual(_testTurnReports.Count, gameReport.GameTurnReports.Count);
            for (int i = 0; i < gameReport.GameTurnReports.Count; i++)
            {
                Assert.IsTrue(gameReport.GameTurnReports.Contains(_testTurnReports.ToArray()[i]));
            }
        }

        [DataRow(-1)]
        [DataRow(-111)]
        [DataRow(-123123)]
        [DataTestMethod]
        public void Test_Replay_Invalid_Timeout_ArgumentException(int timeout)
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => _testGameReport.Replay(timeout));
            Assert.AreEqual("Timeout must be greater than or equal to 0!", exception.Message);
        }

        [TestMethod]
        public void Test_Replay_Console_Write_Check()
        {
            _testGameReport.Replay(0);
            foreach (var turnReport in _testGameReport.GameTurnReports)
            {
                Assert.IsTrue(ConsoleOutput.ToString().Contains(turnReport.ToString()));
            }

            Assert.IsTrue(ConsoleOutput.ToString().Contains($"Game result: {GameEngine.GameStatusToString(_testGameReport.GameTurnReports.Last().GameStatus)}"));

            if (_testGameReport.GameMode.HasValue)
            {
                Assert.IsTrue(ConsoleOutput.ToString().Contains($"Game mode: {GameEngine.GameModeToString(_testGameReport.GameMode.Value)}"));
            }
        }

        [TestMethod]
        public void Test_Replay_No_Turn_Records()
        {
            var report = new GameReportRecord();
            var excpetion = Assert.ThrowsException<Exception>(() => report.Replay(0));
            Assert.AreEqual("No turns to replay!", excpetion.Message);
        }
    }
}