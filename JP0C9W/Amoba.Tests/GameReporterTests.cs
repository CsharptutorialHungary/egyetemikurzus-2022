using Amoba.Classes;
using Amoba.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Amoba.Tests
{
    [TestClass]
    public class GameReporterTests
    {
        private GameReporter Reporter;
        public GameReporterTests()
        {
            Reporter = new GameReporter();
        }

        [TestInitialize]
        public void Setup()
        {
            Reporter = new GameReporter();
        }

        [TestMethod]
        public void Test_GameReporter_Constructor()
        {
            var reporter = new GameReporter();
            Assert.AreEqual(0, reporter.GameReport.GameTurnReports.Count);
            Assert.AreEqual(null, reporter.GameReport.GameMode);
        }


        [DataRow(1, GameStatus.DRAW, 10, 1, 1, BoardCellValue.BLACK)]
        [DataRow(10, GameStatus.BLACK_WON, 100, 12, 1, BoardCellValue.WHITE)]
        [DataRow(100, GameStatus.WHITE_WON, 12, 1, 0, BoardCellValue.BLACK)]
        [DataTestMethod]
        public void Test_SaveTurn_Method(int turn, GameStatus status, int size, int x, int y, BoardCellValue value)
        {
            Assert.AreEqual(0, Reporter.GameReport.GameTurnReports.Count);
            var turnReport = new GameTurnReportRecord(turn, status, new Board(size).CopyCells(), new BoardCell(x, y, value));
            Reporter.SaveTurn(turnReport);
            Assert.AreEqual(1, Reporter.GameReport.GameTurnReports.Count);
            Assert.IsTrue(Reporter.GameReport.GameTurnReports.Contains(turnReport));
        }

        [DataRow("asd.json")]
        [DataRow("json")]
        [DataRow("xd")]
        [DataRow("a.txt")]
        [DataRow("aer")]
        [DataRow("1.1")]
        [DataTestMethod]
        public void Test_LoadGameFromFileAsync_FileNotFoundException(string file)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
            }

            var exception = Assert.ThrowsExceptionAsync<FileNotFoundException>(async () => await Reporter.LoadGameFromFileAsync(file)).Result;
            Assert.AreEqual($"The given saved game file ({file}) doesn't exist!", exception.Message);
        }

        [DataRow("test.json")]
        [DataRow("test.txt")]
        [DataTestMethod]
        public void Test_LoadGameFromFileAsync_File_Content_Is_Not_Serilized_Data(string filePath)
        {
            var writer = new StreamWriter(filePath);
            writer.WriteLine("Invalid");
            writer.Dispose();
            _ = Assert.ThrowsExceptionAsync<JsonException>(async () => await Reporter.LoadGameFromFileAsync(filePath)).Result;
            File.Delete(filePath);
        }

        [DataRow("test.txt", "{\"GameMode\": null, \"GameTurnReports\": []}")]
        [DataRow("test.json", "{\"GameMode\": 1, \"GameTurnReports\": null}")]
        [DataRow("test.txt", "{\"GameMode\": null, \"GameTurnReports\": null}")]
        [DataTestMethod]
        public void Test_LoadGameFromFileAsync_File_Null_Data(string filePath, string data)
        {
            var writer = new StreamWriter(filePath);
            writer.WriteLine(data);
            writer.Dispose();
            var exception = Assert.ThrowsExceptionAsync<Exception>(async () => await Reporter.LoadGameFromFileAsync(filePath)).Result;
            Assert.AreEqual("Game file content is invalid!", exception.Message);
            File.Delete(filePath);
        }

        [DataRow("test.txt", "{\"GameMode\": -1, \"GameTurnReports\": []}")]
        [DataRow("test.json", "{\"GameMode\": 111, \"GameTurnReports\": []}")]
        [DataRow("test.txt", "{\"GameMode\": -23, \"GameTurnReports\": []}")]
        [DataTestMethod]
        public void Test_LoadGameFromFileAsync_File_Invalid_GameMode(string filePath, string data)
        {
            var writer = new StreamWriter(filePath);
            writer.WriteLine(data);
            writer.Dispose();
            var exception = Assert.ThrowsExceptionAsync<ArgumentException>(async () => await Reporter.LoadGameFromFileAsync(filePath)).Result;
            Assert.AreEqual("Invalid game mode!", exception.Message);
            File.Delete(filePath);
        }

        [DataRow(
            "test.json",
            "{\"GameMode\":2,\"GameTurnReports\":[{\"TurnIndex\":1,\"GameStatus\":3,\"GameBoardStatus\":" +
            "[[\"#\",\"#\",\"#\",\"#\",\"#\"]," +
            "[\"#\",\"#\",\"#\",\"#\",\"#\"]," +
            "[\"O\",\"#\",\"#\",\"#\",\"#\"]," +
            "[\"#\",\"#\",\"#\",\"#\",\"#\"]," +
            "[\"#\",\"#\",\"#\",\"#\",\"#\"]]," +
            "\"Move\":{\"X\":0,\"Y\":2,\"Value\":79}}]}"
        )]
        [DataTestMethod]
        public void Test_ReplayGameAsync_Method(string filePath, string data)
        {
            var writer = new StreamWriter(filePath);
            writer.WriteLine(data);
            writer.Dispose();
            Reporter.ReplayGameAsync(filePath).Wait();
            Assert.AreEqual(1, Reporter.GameReport.GameTurnReports.Count);
            var turnReport = Reporter.GameReport.GameTurnReports.First();
            Assert.AreEqual(1, turnReport.TurnIndex);
            Assert.AreEqual(GameStatus.NOT_FINISHED, turnReport.GameStatus);
            Assert.AreEqual(0, turnReport.Move.X);
            Assert.AreEqual(2, turnReport.Move.Y);
            Assert.AreEqual(BoardCellValue.WHITE, turnReport.Move.Value);
            File.Delete(filePath);
        }

        [TestMethod]
        public void Test_SaveGameToFileAsync_Method()
        {
            var board = new Board(6);
            var move = new BoardCell(0, 1, BoardCellValue.WHITE);
            board.SetCell(move);
            Reporter.SaveTurn(new GameTurnReportRecord(1, GameStatus.NOT_FINISHED, board.CopyCells(), move));
            var filePath = Reporter.SaveGameToFileAsync().Result;
            Assert.IsTrue(File.Exists(filePath));
            File.Delete(filePath);
        }
    }
}