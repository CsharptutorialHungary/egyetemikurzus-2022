using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;
using Amoba.Interfaces;

namespace Amoba.Tests
{
    [TestClass]
    public class ProgramTests
    {
        private StringBuilder ConsoleOutput { get; set; }

        public ProgramTests()
        {
            ConsoleOutput = new StringBuilder();
        }

        [TestInitialize]
        public void Setup()
        {
            Console.SetOut(new StringWriter(ConsoleOutput));
            ConsoleOutput.Clear();
        }

        [DataRow("play 1 1 1 1")]
        [DataRow("play 1")]
        [DataRow("replay 1")]
        [DataRow("replay 1 1 1")]
        [DataRow("replay")]
        [DataRow("play")]
        [DataRow("")]
        [DataRow("xd")]
        [DataTestMethod]
        public void Test_Initialize_Invalid_Arguments_Count(string argsStr)
        {
            var exception = Assert.ThrowsException<Exception>(() => Program.Initialize(argsStr.Split(' ')));
            Assert.IsTrue(exception.Message.Contains("Invalid arguments!"));
        }

        [DataRow("plaay 1 2")]
        [DataRow("plaay a 2")]
        [DataRow("plaay 1 b")]
        [DataRow("replayy 1 2")]
        [DataRow("replayy 1 xd")]
        [DataRow("replayy 1.json 2")]
        [DataTestMethod]
        public void Test_Initialize_Invalid_Engine_Mode(string argsStr)
        {
            var exception = Assert.ThrowsException<Exception>(() => Program.Initialize(argsStr.Split(' ')));
            Assert.IsTrue(exception.Message.Contains("is an invalid mode!"));
        }

        [DataRow("replay asd.json 123")]
        [DataRow("replay a.json 2")]
        [DataRow("replay a.txt 1")]
        [DataRow("replay 123 v")]
        [DataTestMethod]
        public void Test_Initialize_Replay_Invalid_File(string argsStr)
        {
            var exception = Assert.ThrowsException<Exception>(() => Program.Initialize(argsStr.Split(' ')));
            Assert.AreEqual("Game file doesn't exists!", exception.Message);
        }

        [DataRow("play a 1")]
        [DataRow("play a1 b")]
        [DataRow("play 1o b")]
        [DataRow("play _ b")]
        [DataRow("play 1.2 b")]
        [DataTestMethod]
        public void Test_Initialize_Play_Invalid_Board_Size(string argsStr)
        {
            var exception = Assert.ThrowsException<Exception>(() => Program.Initialize(argsStr.Split(' ')));
            Assert.AreEqual("The required board size is an invalid integer!", exception.Message);
        }

        [DataRow("play 5 -1")]
        [DataRow("play 15 a")]
        [DataRow("play 25 --1")]
        [DataRow("play 55 -123-")]
        [DataRow("play 15 asd")]
        [DataRow("play 2 4")]
        [DataRow("play 0 123")]
        [DataRow("play 1 1231414")]
        [DataTestMethod]
        public void Test_Initialize_Play_Invalid_GameMode(string argsStr)
        {
            var exception = Assert.ThrowsException<Exception>(() => Program.Initialize(argsStr.Split(' ')));
            Assert.IsTrue(exception.Message.Contains("The required game mode is invalid!"));
        }

        [DataRow("replay test.json -1")]
        [DataRow("replay test.json --1")]
        [DataRow("replay test.json a")]
        [DataRow("replay test.json 1.1")]
        [DataRow("replay test.json -123")]
        [DataTestMethod]
        public void Test_Initialize_Replay_Invalid_Pause_Time(string argsStr)
        {
            var args = argsStr.Split(' ');
            var file = File.Create(args[1]);
            file.Dispose();
            var exception = Assert.ThrowsException<Exception>(() => Program.Initialize(args));
            Assert.IsTrue(exception.Message.Contains("is an invalid pause time!"));
            File.Delete(args[1]);
        }

        [DataRow(-1, 5)]
        [DataRow(3, 123)]
        [DataRow(4, 0)]
        [DataRow(123, 2)]
        [DataRow(-123, 234)]
        [DataTestMethod]
        public void Test_StartEngine_Invalid_GameMode(int gameMode, int boardSize)
        {
            Program.StartEngine(gameMode, boardSize);
            Assert.IsTrue(ConsoleOutput.ToString().Contains("GameEngine error"));
        }

        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(10)]
        [DataTestMethod]
        public void Test_StartEngine_With_Valid_Arguments(int boardSize)
        {
            Program.StartEngine((int)GameMode.AI_VS_AI, boardSize);
            Assert.IsFalse(ConsoleOutput.ToString().Contains("GameEngine error"));
        }

        [DataRow("asd", 0)]
        [DataRow("xd.json", 123)]
        [DataRow("txt.json", 2)]
        [DataRow("json.txt", 4)]
        [DataRow("123", 1)]
        [DataRow("123.1", 132)]
        [DataRow("o.O", 2342)]
        [DataTestMethod]
        public void Test_StartReporter_File_Not_Exists(string filePath, int pauseTime)
        {
            var file = File.Create(filePath);
            file.Dispose();
            Program.StartReporter(filePath, pauseTime);
            Assert.IsTrue(ConsoleOutput.ToString().Contains("GameReporter error"));
            File.Delete(filePath);
        }

        [DataRow("asd", -10)]
        [DataRow("xd.json", -123)]
        [DataRow("txt.json", -1)]
        [DataRow("o.O", -2342)]
        [DataTestMethod]
        public void Test_StartReporter_Invalid_Pause_Time(string filePath, int pauseTime)
        {
            var file = File.Create(filePath);
            file.Dispose();
            Program.StartReporter(filePath, pauseTime);
            Assert.IsTrue(ConsoleOutput.ToString().Contains("GameReporter error"));
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
        public void Test_StartReporter_Valid_Arguments(string filePath, string data)
        {
            var writer = new StreamWriter(filePath);
            writer.WriteLine(data);
            writer.Dispose();
            Program.StartReporter(filePath, 0);
            Assert.IsTrue(ConsoleOutput.ToString().Contains("Turn: 1."));
            Assert.IsTrue(ConsoleOutput.ToString().Contains('#'));
            Assert.IsTrue(ConsoleOutput.ToString().Contains('O'));
            Assert.IsTrue(ConsoleOutput.ToString().Contains($"Move: Color: WHITE, Row: {2 + 1}, Column: {0 + 1}"));
            Assert.IsTrue(ConsoleOutput.ToString().Contains($"1  # # # # #"));
            Assert.IsTrue(ConsoleOutput.ToString().Contains($"2  # # # # #"));
            Assert.IsTrue(ConsoleOutput.ToString().Contains($"3  O # # # #"));
            Assert.IsTrue(ConsoleOutput.ToString().Contains($"4  # # # # #"));
            Assert.IsTrue(ConsoleOutput.ToString().Contains($"5  # # # # #"));
            Assert.IsTrue(ConsoleOutput.ToString().Contains($"Game result: Game has not yet finished"));
            File.Delete(filePath);
        }

        [DataRow("replat")]
        [DataRow("playe")]
        [DataRow("amoba")]
        [DataRow("1 1 1 1")]
        [DataRow("play 1 1 1")]
        [DataRow("play newGame.json 1")]
        [DataRow("replay asdas.dasdasdasd.json 1")]
        [DataTestMethod]
        public void Test_Main_Invalid_Arguments(string argsStr)
        {
            Assert.AreEqual(1, Program.Main(argsStr.Split(' ')));
        }

        [DataRow("play 5 2")]
        [DataRow("play 10 2")]
        [DataTestMethod]
        public void Test_Main_Valid_Play_Arguments(string argsStr)
        {
            Assert.AreEqual(0, Program.Main(argsStr.Split(' ')));
        }

        [DataRow(
            "replay test.json 0",
            "{\"GameMode\":2,\"GameTurnReports\":[{\"TurnIndex\":1,\"GameStatus\":3,\"GameBoardStatus\":" +
            "[[\"#\",\"#\",\"#\",\"#\",\"#\"]," +
            "[\"#\",\"#\",\"#\",\"#\",\"#\"]," +
            "[\"O\",\"#\",\"#\",\"#\",\"#\"]," +
            "[\"#\",\"#\",\"#\",\"#\",\"#\"]," +
            "[\"#\",\"#\",\"#\",\"#\",\"#\"]]," +
            "\"Move\":{\"X\":0,\"Y\":2,\"Value\":79}}]}"
        )]
        [DataRow(
            "replay asd.txt 3",
            "{\"GameMode\":2,\"GameTurnReports\":[{\"TurnIndex\":1,\"GameStatus\":0,\"GameBoardStatus\":" +
            "[[\"#\",\"#\",\"#\",\"#\",\"#\"]," +
            "[\"#\",\"#\",\"#\",\"#\",\"#\"]," +
            "[\"O\",\"O\",\"O\",\"O\",\"O\"]," +
            "[\"#\",\"#\",\"#\",\"#\",\"#\"]," +
            "[\"#\",\"#\",\"#\",\"#\",\"#\"]]," +
            "\"Move\":{\"X\":2,\"Y\":2,\"Value\":79}}]}"
        )]
        [DataTestMethod]
        public void Test_Main_Valid_Replay_Arguments(string argsStr, string data)
        {
            var args = argsStr.Split(' ');
            var writer = new StreamWriter(args[0]);
            writer.WriteLine(data);
            writer.Dispose();
            Assert.AreEqual(0, Program.Main(args));
            File.Delete(args[0]);
        }
    }
}