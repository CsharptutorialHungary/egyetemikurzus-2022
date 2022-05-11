using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Amoba.Classes;
using Amoba.Interfaces;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace Amoba.Tests
{
    [TestClass]
    public class GameEngineTests
    {
        private StringBuilder ConsoleOutput { get; set; }
        private readonly List<IBoard<char>> BlackRowWinnerBoards;
        private readonly List<IBoard<char>> BlackColWinnerBoards;
        private readonly List<IBoard<char>> BlackDiagWinnerBoards;
        private readonly List<IBoard<char>> WhiteRowWinnerBoards;
        private readonly List<IBoard<char>> WhiteColWinnerBoards;
        private readonly List<IBoard<char>> WhiteDiagWinnerBoards;
        private readonly List<IBoard<char>> WhiteFullBoards;
        private readonly List<IBoard<char>> BlackFullBoards;
        private readonly List<IBoard<char>> EmptyBoards;
        private readonly IBoard<char> DrawBoard;

        public enum WinType
        {
            ROW = 0,
            COL = 1,
            DIAG = 2
        }
        public static Board CreateWinnerBoard(int boardSize, PlayerColor color, WinType type)
        {
            var board = new Board(boardSize);
            for (int i = 1; i <= 5; i++)
            {
                switch (type)
                {
                    case WinType.ROW:
                        board.SetCell(board.BoardSize - i, board.BoardSize - 1, GameEngine.ColorToValue(color));
                        if (i != 5)
                        {
                            board.SetCell(board.BoardSize - i, board.BoardSize - 2, GameEngine.ColorToValue(1 - color));
                        }
                        break;
                    case WinType.COL:
                        board.SetCell(board.BoardSize - 1, board.BoardSize - i, GameEngine.ColorToValue(color));
                        if (i != 5)
                        {
                            board.SetCell(board.BoardSize - 2, board.BoardSize - i, GameEngine.ColorToValue(1 - color));
                        }
                        break;
                    case WinType.DIAG:
                        board.SetCell(board.BoardSize - i, board.BoardSize - i, GameEngine.ColorToValue(color));
                        if (i != 5)
                        {
                            board.SetCell(board.BoardSize - 1, i - 1, GameEngine.ColorToValue(1 - color));
                        }
                        break;
                }
            }
            return board;
        }

        public static Board CreateFilledBoard(int boardSize, PlayerColor color)
        {
            var board = new Board(boardSize);
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    board.SetCell(j, i, GameEngine.ColorToValue(color));
                }
            }
            return board;
        }

        public static Board CreateDrawBoard()
        {
            var board = new Board(6);
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j == 2)
                        {
                            board.SetCell(j, i, BoardCellValue.BLACK);
                        }
                        else
                        {
                            board.SetCell(j, i, BoardCellValue.WHITE);
                        }
                    }
                    else
                    {
                        if (j == 2)
                        {
                            board.SetCell(j, i, BoardCellValue.WHITE);
                        }
                        else
                        {
                            board.SetCell(j, i, BoardCellValue.BLACK);
                        }
                    }
                }
            }
            return board;
        }

        public GameEngineTests()
        {
            ConsoleOutput = new StringBuilder();
            BlackRowWinnerBoards = new();
            BlackRowWinnerBoards.Add(CreateWinnerBoard(5, PlayerColor.BLACK, WinType.ROW));
            BlackRowWinnerBoards.Add(CreateWinnerBoard(50, PlayerColor.BLACK, WinType.ROW));
            BlackRowWinnerBoards.Add(CreateWinnerBoard(100, PlayerColor.BLACK, WinType.ROW));
            WhiteRowWinnerBoards = new();
            WhiteRowWinnerBoards.Add(CreateWinnerBoard(5, PlayerColor.WHITE, WinType.ROW));
            WhiteRowWinnerBoards.Add(CreateWinnerBoard(50, PlayerColor.WHITE, WinType.ROW));
            WhiteRowWinnerBoards.Add(CreateWinnerBoard(100, PlayerColor.WHITE, WinType.ROW));
            BlackColWinnerBoards = new();
            BlackColWinnerBoards.Add(CreateWinnerBoard(5, PlayerColor.BLACK, WinType.COL));
            BlackColWinnerBoards.Add(CreateWinnerBoard(50, PlayerColor.BLACK, WinType.COL));
            BlackColWinnerBoards.Add(CreateWinnerBoard(100, PlayerColor.BLACK, WinType.COL));
            WhiteColWinnerBoards = new();
            WhiteColWinnerBoards.Add(CreateWinnerBoard(5, PlayerColor.WHITE, WinType.COL));
            WhiteColWinnerBoards.Add(CreateWinnerBoard(50, PlayerColor.WHITE, WinType.COL));
            WhiteColWinnerBoards.Add(CreateWinnerBoard(100, PlayerColor.WHITE, WinType.COL));
            BlackDiagWinnerBoards = new();
            BlackDiagWinnerBoards.Add(CreateWinnerBoard(5, PlayerColor.BLACK, WinType.DIAG));
            BlackDiagWinnerBoards.Add(CreateWinnerBoard(50, PlayerColor.BLACK, WinType.DIAG));
            BlackDiagWinnerBoards.Add(CreateWinnerBoard(100, PlayerColor.BLACK, WinType.DIAG));
            WhiteDiagWinnerBoards = new();
            WhiteDiagWinnerBoards.Add(CreateWinnerBoard(5, PlayerColor.WHITE, WinType.DIAG));
            WhiteDiagWinnerBoards.Add(CreateWinnerBoard(50, PlayerColor.WHITE, WinType.DIAG));
            WhiteDiagWinnerBoards.Add(CreateWinnerBoard(100, PlayerColor.WHITE, WinType.DIAG));
            WhiteFullBoards = new();
            WhiteFullBoards.Add(CreateFilledBoard(Board.MIN_BOARD_SIZE, PlayerColor.WHITE));
            WhiteFullBoards.Add(CreateFilledBoard(Board.MAX_BOARD_SIZE, PlayerColor.WHITE));
            BlackFullBoards = new();
            BlackFullBoards.Add(CreateFilledBoard(Board.MIN_BOARD_SIZE, PlayerColor.BLACK));
            BlackFullBoards.Add(CreateFilledBoard(Board.MAX_BOARD_SIZE, PlayerColor.BLACK));
            EmptyBoards = new();
            EmptyBoards.Add(new Board(Board.MIN_BOARD_SIZE));
            EmptyBoards.Add(new Board(Board.MAX_BOARD_SIZE));
            DrawBoard = CreateDrawBoard();
        }

        [TestInitialize]
        public void Setup() 
        {
            Console.SetOut(new StringWriter(ConsoleOutput));
            ConsoleOutput.Clear();
        }
        
        [DataRow("a")]
        [DataRow("xd")]
        [DataRow("reeplay")]
        [DataRow("pley")]
        [DataTestMethod]
        public void Test_Static_Is_ValidEngineMode_False(string mode)
        {
            Assert.IsFalse(GameEngine.IsValidEngineMode(mode));
        }

        [DataRow("play")]
        [DataRow("PlAy")]
        [DataRow("PLAY")]
        [DataRow("replay")]
        [DataRow("RePlAy")]
        [DataRow("REPLAY")]
        [DataTestMethod]
        public void Test_Static_Is_ValidEngineMode_True(string mode)
        {
            Assert.IsTrue(GameEngine.IsValidEngineMode(mode));
        }

        [DataRow(0, 0, BoardCellValue.BLACK)]
        [DataRow(10, 10, BoardCellValue.WHITE)]
        [DataRow(11, 11, BoardCellValue.BLACK)]
        [DataRow(1, 10, BoardCellValue.WHITE)]
        [DataRow(10, 1, BoardCellValue.BLACK)]
        [DataRow(0, 123, BoardCellValue.WHITE)]
        [DataRow(123, 0, BoardCellValue.BLACK)]
        [DataTestMethod]
        public void Test_Static_IsMoveValid_False(int x, int y, BoardCellValue value)
        {
            var move = new BoardCell(x, y, value);
            var board = new Board(10);
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    board.SetCell(new BoardCell(i, j, value));
                }
            }
            Assert.IsFalse(GameEngine.IsMoveValid(move, board));
        }

        [DataRow(0, 0, BoardCellValue.BLACK)]
        [DataRow(9, 9, BoardCellValue.WHITE)]
        [DataRow(9, 0, BoardCellValue.BLACK)]
        [DataRow(0, 9, BoardCellValue.WHITE)]
        [DataRow(3, 2, BoardCellValue.BLACK)]
        [DataRow(4, 5, BoardCellValue.WHITE)]
        [DataRow(5, 1, BoardCellValue.BLACK)]
        [DataTestMethod]
        public void Test_Static_IsMoveValid_True(int x, int y, BoardCellValue value)
        {
            var move = new BoardCell(x, y, value);
            var board = new Board(10);
            Assert.IsTrue(GameEngine.IsMoveValid(move, board));
        }

        [DataRow(PlayerColor.WHITE)]
        [DataRow(PlayerColor.BLACK)]
        [DataTestMethod]
        public void Test_Static_ColorToString(PlayerColor color)
        {
            Assert.AreEqual(color == PlayerColor.WHITE ? "White" : "Black", GameEngine.ColorToString(color));
        }

        [DataRow(PlayerColor.WHITE)]
        [DataRow(PlayerColor.BLACK)]
        [DataTestMethod]
        public void Test_Static_ColorToValue(PlayerColor color)
        {
            Assert.AreEqual(color == PlayerColor.WHITE ? BoardCellValue.WHITE : BoardCellValue.BLACK, GameEngine.ColorToValue(color));
        }

        [DataRow(GameStatus.BLACK_WON)]
        [DataRow(GameStatus.WHITE_WON)]
        [DataRow(GameStatus.DRAW)]
        [DataRow(GameStatus.NOT_FINISHED)]
        [DataRow(4)]
        [DataRow((GameStatus)14)]
        [DataTestMethod]
        public void Test_Static_GameStatusToString(GameStatus gameStatus)
        {
            switch (gameStatus)
            {
                case GameStatus.DRAW:
                    Assert.AreEqual("Draw", GameEngine.GameStatusToString(gameStatus));
                    break;
                case GameStatus.NOT_FINISHED:
                    Assert.AreEqual("Game has not yet finished", GameEngine.GameStatusToString(gameStatus));
                    break;
                case GameStatus.WHITE_WON:
                    Assert.AreEqual("White (O) won", GameEngine.GameStatusToString(gameStatus));
                    break;
                case GameStatus.BLACK_WON:
                    Assert.AreEqual("Black (X) won", GameEngine.GameStatusToString(gameStatus));
                    break;
            }
        }

        [DataRow("Draw")]
        [DataRow("Game has not yet finished")]
        [DataRow("White (O) won")]
        [DataRow("Black (X) won")]
        [DataTestMethod]
        public void Test_Static_GameStatusToString_Valid(string gameStatus)
        {
            switch (gameStatus)
            {
                case "Draw":
                    Assert.AreEqual(GameStatus.DRAW, GameEngine.StringToGameStatus(gameStatus));
                    break;
                case "Game has not yet finished":
                    Assert.AreEqual(GameStatus.NOT_FINISHED, GameEngine.StringToGameStatus(gameStatus));
                    break;
                case "White (O) won":
                    Assert.AreEqual(GameStatus.WHITE_WON, GameEngine.StringToGameStatus(gameStatus));
                    break;
                case "Black (X) won":
                    Assert.AreEqual(GameStatus.BLACK_WON, GameEngine.StringToGameStatus(gameStatus));
                    break;
            }
        }

        [DataRow("Draaw")]
        [DataRow("Game has nasdot yet finished")]
        [DataRow("Whitea (O) won")]
        [DataRow("Black  (X) won")]
        [DataRow("Black")]
        [DataRow("White")]
        [DataTestMethod]
        public void Test_Static_GameStatusToString_Invalid(string gameStatus)
        {
            var exception = Assert.ThrowsException<ArgumentException>( () => GameEngine.StringToGameStatus(gameStatus));
            Assert.AreEqual("Invalid game status!", exception.Message);
        }

        [DataRow(GameMode.REAL_VS_REAL)]
        [DataRow(GameMode.REAL_VS_AI)]
        [DataRow(GameMode.AI_VS_AI)]
        [DataRow(4)]
        [DataRow((GameStatus)14)]
        [DataTestMethod]
        public void Test_Static_GameModeToString(GameMode gameMode)
        {
            switch (gameMode)
            {
                case GameMode.REAL_VS_REAL:
                    Assert.AreEqual("Real vs Real", GameEngine.GameModeToString(gameMode));
                    break;
                case GameMode.REAL_VS_AI:
                    Assert.AreEqual("Real vs AI", GameEngine.GameModeToString(gameMode));
                    break;
                case GameMode.AI_VS_AI:
                    Assert.AreEqual("AI vs AI", GameEngine.GameModeToString(gameMode));
                    break;
            }
        }

        [DataRow("Real vs Real")]
        [DataRow("Real vs AI")]
        [DataRow("AI vs AI")]
        [DataTestMethod]
        public void Test_Static_StringToGameMode_Valid(string gameMode)
        {
            switch (gameMode)
            {
                case "Real vs Real":
                    Assert.AreEqual(GameMode.REAL_VS_REAL, GameEngine.StringToGameMode(gameMode));
                    break;
                case "Real vs AI":
                    Assert.AreEqual(GameMode.REAL_VS_AI, GameEngine.StringToGameMode(gameMode));
                    break;
                case "AI vs AI":
                    Assert.AreEqual(GameMode.AI_VS_AI, GameEngine.StringToGameMode(gameMode));
                    break;
            }
        }

        [DataRow("Real VS Real")]
        [DataRow("ai VS ai")]
        [DataRow("Real vs. Real")]
        [DataRow("asd")]
        [DataRow(":)")]
        [DataRow(":/")]
        [DataRow(":(")]
        [DataTestMethod]
        public void Test_Static_StringToGameMode_Invalid(string gameMode)
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => GameEngine.StringToGameMode(gameMode));
            Assert.AreEqual("Invalid game mode!", exception.Message);
        }

        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataTestMethod]
        public void Test_Static_IntToGameMode_Valid(int gameMode)
        {
            switch(gameMode)
            {
                case 0:
                    Assert.AreEqual(GameMode.REAL_VS_REAL, GameEngine.IntToGameMode(gameMode));
                    break;
                case 1:
                    Assert.AreEqual(GameMode.REAL_VS_AI, GameEngine.IntToGameMode(gameMode));
                    break;
                case 2:
                    Assert.AreEqual(GameMode.AI_VS_AI, GameEngine.IntToGameMode(gameMode));
                    break;
            }
        }

        [DataRow(-1)]
        [DataRow(1123)]
        [DataRow(3)]
        [DataTestMethod]
        public void Test_Static_IntToGameMode_Invalid(int gameMode)
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => GameEngine.IntToGameMode(gameMode));
            Assert.AreEqual("Invalid game mode!", exception.Message);
        }

        [DataTestMethod]
        public void Test_GameEngine_Constructor()
        {
            var engine = new GameEngine(new GameReporter(), 5);
            Assert.AreEqual(5, engine.Board.BoardSize);
            Assert.AreEqual(-1, engine.TurnIndex);
            Assert.AreEqual(2, engine.Players.Length);
            Assert.AreEqual(PlayerColor.WHITE, engine.PlayerTurn);
            Assert.IsFalse(engine.IsGameRunning);
            Assert.IsNotNull(engine.Reporter);
            Assert.IsNull(engine.PrevMove);
            Assert.IsNull(engine.Mode);
        }

        [DataRow(GameMode.REAL_VS_REAL)]
        [DataRow(GameMode.REAL_VS_AI)]
        [DataRow(GameMode.AI_VS_AI)]
        [DataTestMethod]
        public void Test_AssignColorToPlayers_Game_Is_Running(GameMode gameMode)
        {
            var engine = new GameEngine(new GameReporter(), 10);
            var getMethodInfo = typeof(GameEngine).GetProperty("IsGameRunning")?.GetSetMethod(true);
            object[] parameters = { true };
            getMethodInfo?.Invoke(engine, parameters);
            engine.AssignColorToPlayers(gameMode);
            Assert.IsTrue(engine.IsGameRunning);
            Assert.IsTrue(ConsoleOutput.ToString().Contains("Can't assign colors to players, because a game is already running!"));
            Assert.AreEqual(2, engine.Players.Length);
        }

        [DataRow(GameMode.REAL_VS_REAL)]
        [DataRow(GameMode.REAL_VS_AI)]
        [DataRow(GameMode.AI_VS_AI)]
        [DataTestMethod]
        public void Test_AssignColorToPlayers_Game_Is_Not_Running(GameMode gameMode)
        {
            var engine = new GameEngine(new GameReporter(), 10);
            engine.AssignColorToPlayers(gameMode);
            switch (gameMode)
            {
                case GameMode.REAL_VS_REAL:
                    Assert.AreEqual(PlayerType.REAL, engine.Players[0].Type);
                    Assert.AreEqual(PlayerType.REAL, engine.Players[1].Type);
                    break;
                case GameMode.AI_VS_AI:
                    Assert.AreEqual(PlayerType.AI, engine.Players[0].Type);
                    Assert.AreEqual(PlayerType.AI, engine.Players[1].Type);
                    break;
                case GameMode.REAL_VS_AI:
                    Assert.AreNotEqual(engine.Players[0].Type, engine.Players[1].Type);
                    break;
            }
            Assert.AreEqual(2, engine.Players.Length);
            Assert.AreNotEqual(engine.Players[0].Color, engine.Players[1].Color);
        }

        [TestMethod]
        public void Test_Players_Get_Accessor_Returns_Copy()
        {
            var engine = new GameEngine(new GameReporter(), 10);
            engine.AssignColorToPlayers(GameMode.AI_VS_AI);
            engine.Players[0] = new ConsolePlayer();
            var player = engine.Players[0];
            Assert.AreNotEqual(typeof(ConsolePlayer), player.GetType());
        }

        [TestMethod]
        public void Test_StartNewGame_Game_Is_Running()
        {
            var engine = new GameEngine(new GameReporter(), 10);
            object[] parameters = { true };
            typeof(GameEngine).GetProperty("IsGameRunning")?.GetSetMethod(true)?.Invoke(engine, parameters);
            engine.StartNewGame(GameMode.AI_VS_AI);
            Assert.IsTrue(engine.IsGameRunning);
            Assert.IsTrue(ConsoleOutput.ToString().Contains("A new game cannot be started, because a game is already running!"));
        }

        [TestMethod]
        public void Test_StartNewGame_AI_VS_AI()
        {
            var engine = new GameEngine(new GameReporter(), 5);
            engine.StartNewGame(GameMode.AI_VS_AI);
            var log = ConsoleOutput.ToString();
            Assert.IsTrue(log.Contains("Turn: 1"));
            Assert.IsTrue(log.Contains($"Game mode: {GameEngine.GameModeToString(GameMode.AI_VS_AI)}"));
            Assert.IsTrue(log.Contains("Move:"));
            Assert.IsTrue(log.Contains((char)BoardCellValue.BLACK));
            Assert.IsTrue(log.Contains((char)BoardCellValue.WHITE));
            Assert.IsTrue(log.Contains((char)BoardCellValue.EMPTY));
            Assert.IsFalse(engine.IsGameRunning);
            Assert.AreEqual(GameMode.AI_VS_AI, engine.Mode);
        }

        [TestMethod]
        public void Test_RequestMove_Method_Game_Is_Not_Running()
        {
            var engine = new GameEngine(new GameReporter(), 5);
            typeof(GameEngine).GetMethod("RequestMove", BindingFlags.NonPublic)?.Invoke(engine, null);
            Assert.IsFalse(engine.IsGameRunning);
            Assert.AreEqual(PlayerColor.WHITE, engine.PlayerTurn);
            Assert.IsNull(engine.PrevMove);
        }

        [TestMethod]
        public void Test_RequestMove_Method_Game_Is_Running_Null_Players()
        {
            var engine = new GameEngine(new GameReporter(), 5);
            object[] parameters = { true };
            typeof(GameEngine).GetProperty("IsGameRunning")?.GetSetMethod(true)?.Invoke(engine, parameters);
            Assert.IsTrue(engine.IsGameRunning);
            typeof(GameEngine).GetMethod("RequestMove", BindingFlags.NonPublic)?.Invoke(engine, null);
            Assert.AreEqual(PlayerColor.WHITE, engine.PlayerTurn);
            Assert.IsNull(engine.PrevMove);
        }

        [DataRow(0)]
        [DataRow(1)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(99)]
        [DataRow(100)]
        [DataRow(101)]
        [DataTestMethod]
        public void Test_RequestMove_Method_Valid(int size)
        {
            var engine = new GameEngine(new GameReporter(), size);
            engine.AssignColorToPlayers(GameMode.AI_VS_AI);
            object[] parameters = { true };
            typeof(GameEngine).GetProperty("IsGameRunning")?.GetSetMethod(true)?.Invoke(engine, parameters);
            Assert.IsTrue(engine.IsGameRunning);
            typeof(GameEngine).GetMethod("RequestMove", BindingFlags.NonPublic | BindingFlags.Instance)?.Invoke(engine, null);
            Assert.IsNotNull(engine.PrevMove);
            Assert.AreEqual(PlayerColor.BLACK, engine.PlayerTurn);
        }

        [TestMethod]
        public void Test_EndGame_Game_Not_Finished()
        {
            var engine = new GameEngine(new GameReporter(), 5);
            object[] parameters = { true };
            typeof(GameEngine).GetProperty("IsGameRunning")?.GetSetMethod(true)?.Invoke(engine, parameters);
            engine.EndGame();
            Assert.IsTrue(ConsoleOutput.ToString().Contains("Game can not be ended, because it has not yet finished!"));
        }

        [TestMethod]
        public void Test_EndGame_Game_Is_Not_Running()
        {
            var engine = new GameEngine(new GameReporter(), 5);
            engine.EndGame();
            Assert.IsTrue(ConsoleOutput.ToString().Contains("Game is not running!"));
        }

        [TestMethod]
        public void Test_CheckBoardRows_Black_Won()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            foreach (var board in BlackRowWinnerBoards)
            {
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.BLACK_WON ,engine.CheckBoardRows());
            }
        }

        [TestMethod]
        public void Test_CheckBoardRows_White_Won()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            foreach (var board in WhiteRowWinnerBoards)
            {
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.WHITE_WON, engine.CheckBoardRows());
            }
        }

        [TestMethod]
        public void Test_CheckBoardRows_Not_Finished()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            foreach (var board in EmptyBoards)
            {
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.NOT_FINISHED, engine.CheckBoardRows());
            }
        }

        [TestMethod]
        public void Test_CheckBoardRows_Draw()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, DrawBoard);
            Assert.AreEqual(GameStatus.NOT_FINISHED, engine.CheckBoardRows());
        }

        [TestMethod]
        public void Test_CheckBoardCols_Black_Won()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            foreach (var board in BlackColWinnerBoards)
            {
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.BLACK_WON, engine.CheckBoardCols());
            }
        }

        [TestMethod]
        public void Test_CheckBoardCols_White_Won()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            foreach (var board in WhiteColWinnerBoards)
            {
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.WHITE_WON, engine.CheckBoardCols());
            }
        }

        [TestMethod]
        public void Test_CheckBoardCols_Not_Finished()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            foreach (var board in EmptyBoards)
            {
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.NOT_FINISHED, engine.CheckBoardCols());
            }
        }

        [TestMethod]
        public void Test_CheckBoardCols_Draw()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, DrawBoard);
            Assert.AreEqual(GameStatus.NOT_FINISHED, engine.CheckBoardCols());
        }

        [TestMethod]
        public void Test_CheckBoardDiagonals_Black_Won()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            foreach (var board in BlackDiagWinnerBoards)
            {
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.BLACK_WON, engine.CheckBoardDiagonals());
            }
        }

        [TestMethod]
        public void Test_CheckBoardDiagonals_White_Won()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            foreach (var board in WhiteDiagWinnerBoards)
            {
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.WHITE_WON, engine.CheckBoardDiagonals());
            }
        }

        [TestMethod]
        public void Test_CheckBoardDiagonals_Not_Finished()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            foreach (var board in EmptyBoards)
            {
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.NOT_FINISHED, engine.CheckBoardDiagonals());
            }
        }

        [TestMethod]
        public void Test_CheckBoardDiagonals_Draw()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, DrawBoard);
            Assert.AreEqual(GameStatus.NOT_FINISHED, engine.CheckBoardDiagonals());
        }

        [TestMethod]
        public void Test_GetStatus_Black_Won_Diag()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            foreach (var board in BlackDiagWinnerBoards)
            {
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.BLACK_WON, engine.GetStatus());
            }
        }

        [TestMethod]
        public void Test_GetStatus_Black_Won_Col()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            foreach (var board in BlackColWinnerBoards)
            {
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.BLACK_WON, engine.GetStatus());
            }
        }

        [TestMethod]
        public void Test_GetStatus_Black_Won_Row()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            foreach (var board in BlackRowWinnerBoards)
            {
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.BLACK_WON, engine.GetStatus());
            }
        }

        [TestMethod]
        public void Test_GetStatus_Black_Won_Full_Board()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            foreach (var board in BlackFullBoards)
            {
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.BLACK_WON, engine.GetStatus());
            }
        }

        [TestMethod]
        public void Test_GetStatus_White_Won_Diag()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            foreach (var board in WhiteDiagWinnerBoards)
            {
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.WHITE_WON, engine.GetStatus());
            }
        }

        [TestMethod]
        public void Test_GetStatus_White_Won_Col()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            foreach (var board in WhiteColWinnerBoards)
            {
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.WHITE_WON, engine.GetStatus());
            }
        }

        [TestMethod]
        public void Test_GetStatus_White_Won_Row()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            foreach (var board in WhiteRowWinnerBoards)
            {
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.WHITE_WON, engine.GetStatus());
            }
        }

        [TestMethod]
        public void Test_GetStatus_White_Won_Full_Board()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            foreach (var board in WhiteFullBoards)
            {
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.WHITE_WON, engine.GetStatus());
            }
        }

        [TestMethod]
        public void Test_GetStatus_Draw()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, DrawBoard);
            Assert.AreEqual(GameStatus.DRAW, engine.GetStatus());
        }

        [TestMethod]
        public void Test_GetStatus_Not_Finished_Boards()
        {
            var engine = new GameEngine(new GameReporter(), 0);
            foreach (var board in EmptyBoards)
            {
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.NOT_FINISHED, engine.GetStatus());
                board.SetCell(1, 1, BoardCellValue.WHITE);
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.NOT_FINISHED, engine.GetStatus());
                board.SetCell(2, 3, BoardCellValue.BLACK);
                typeof(GameEngine).GetField("_board", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(engine, board);
                Assert.AreEqual(GameStatus.NOT_FINISHED, engine.GetStatus());
            }
        }
    }
}