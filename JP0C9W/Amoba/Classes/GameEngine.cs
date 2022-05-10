using Amoba.Interfaces;

namespace Amoba.Classes
{
    public class GameEngine : IGameEngine
    {
        public static readonly Random RANDOM = new();
        public static readonly string PLAY_MODE = "play";
        public static readonly string REPLAY_MODE = "replay"; 
        private const int MIN_BOARD_SIZE = 5;
        private const int MAX_BOARD_SIZE = 100;
        private readonly string WHITE_WINNER_STATE;
        private readonly string BLACK_WINNER_STATE;
        public IGameReporter Reporter { get; init; }
        public GameMode? Mode { get; private set; }
        public int TurnIndex { get; private set; }
        public IPlayer[] Players { get; private set; }
        public PlayerColor PlayerTurn { get; private set; }
        public bool IsGameRunning { get; private set; }
        public IBoard<char> Board { get; private set; }
        public IBoardCell? PrevMove { get; private set; }

        public static bool IsValidEngineMode(string mode) 
        { 
            return mode.ToLower() == PLAY_MODE || mode.ToLower() == REPLAY_MODE;
        }

        public static bool IsMoveValid(IBoardCell cell, IBoard<char> board)
        {
            return 0 <= cell.Y && cell.Y < board.BoardSize && 0 <= cell.X && cell.X < board.BoardSize && board.Cells.ElementAt(cell.Y)[cell.X] == board.EmptyCell;
        }

        public static string ColorToString(PlayerColor Color)
        {
            return Color == PlayerColor.WHITE ? "White" : "Black"; 
        }
        public static BoardCellValue ColorToValue(PlayerColor Color)
        {
            return Color == PlayerColor.WHITE ? BoardCellValue.WHITE : BoardCellValue.BLACK;
        }

        public static string GameStatusToString(GameStatus gameStatus)
        {
            return gameStatus switch
            {
                GameStatus.DRAW => "Draw",
                GameStatus.BLACK_WON => "Black (X) won",
                GameStatus.WHITE_WON => "White (O) won",
                GameStatus.NOT_FINISHED => "Game has not yet finished",
                _ => throw new Exception("Invalid game status!"),
            };
        }

        public static GameStatus StringToGameStatus(string gameStatus)
        {
            return gameStatus switch
            {
                "Draw" => GameStatus.DRAW,
                "Black (X) won" => GameStatus.BLACK_WON,
                "White (O) won" => GameStatus.WHITE_WON,
                "Game has not yet finished" => GameStatus.NOT_FINISHED,
                _ => throw new Exception("Invalid game status!"),
            };
        }

        public static string GameModeToString(GameMode gameMode)
        {
            return gameMode switch
            {
                GameMode.REAL_VS_REAL => "Real vs Real",
                GameMode.REAL_VS_AI => "Real vs AI",
                GameMode.AI_VS_AI => "AI vs AI",
                _ => throw new ArgumentException("Unknown game mode!"),
            };
        }

        public static GameMode StringToGameMode(string gameMode)
        {
            return gameMode switch
            {
                "Real vs Real" => GameMode.REAL_VS_REAL,
                "Real vs AI" => GameMode.REAL_VS_AI,
                "AI vs AI" => GameMode.AI_VS_AI,
                _ => throw new ArgumentException("Unknown game mode!"),
            };
        }

        public static GameMode IntToGameMode(int gameModeCode)
        {
            return gameModeCode switch
            {
                0 => GameMode.REAL_VS_REAL,
                1 => GameMode.REAL_VS_AI,
                2 => GameMode.AI_VS_AI,
                _ => throw new ArgumentException("Unknown game mode!"),
            };
        }

        public GameEngine(IGameReporter gameReporter, int boardSize) {
            Reporter = gameReporter;
            WHITE_WINNER_STATE = new((char)BoardCellValue.WHITE, MIN_BOARD_SIZE);
            BLACK_WINNER_STATE = new((char)BoardCellValue.BLACK, MIN_BOARD_SIZE);
            Board = new Board(MIN_BOARD_SIZE, MAX_BOARD_SIZE, boardSize, (char)BoardCellValue.EMPTY);
            IsGameRunning = false;
            TurnIndex = -1;
            Players = new IPlayer[2];
            PlayerTurn = PlayerColor.WHITE;
        }

        private void RequestMove()
        {
            try
            {
                var player = Players[(int)PlayerTurn];
                var action = player.GetMove(Board, PrevMove);
                while (!IsMoveValid(action, Board))
                {
                    action = player.GetMove(Board, PrevMove);
                }
                PrevMove = action;
                Board.SetCell(action);
                PlayerTurn = (PlayerColor)(1 - (int)PlayerTurn);
                // save turn
                Reporter.SaveTurn(new GameTurnReportRecord(TurnIndex++, GetStatus(), Board.CopyCells(), new BoardCell(action)));
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void AssignColorToPlayers(GameMode mode)
        {
            if (IsGameRunning)
            {
                Console.Error.WriteLine("Can't assign colors to players, because a game is already running!");
                return;
            }

            int coinFlip = RANDOM.Next(0, 2);
            switch (mode)
            {
                case GameMode.REAL_VS_AI:
                    Players[coinFlip] = new ConsolePlayer((PlayerColor)coinFlip);
                    Players[1 - coinFlip] = new RandomPlayer((PlayerColor)(1 - coinFlip), Board);
                    break;
                case GameMode.AI_VS_AI:
                    Players[coinFlip] = new RandomPlayer((PlayerColor)coinFlip, Board);
                    Players[1 - coinFlip] = new RandomPlayer((PlayerColor)(1 - coinFlip), Board);
                    break;
                default:
                    Players[coinFlip] = new ConsolePlayer((PlayerColor)coinFlip);
                    Players[1 - coinFlip] = new ConsolePlayer((PlayerColor)(1 - coinFlip));
                    break;
            }
        }

        public void StartNewGame(GameMode mode)
        {
            if (IsGameRunning)
            {
                Console.Error.WriteLine("A new game cannot be started, bacuase a game is already running!");
                return;
            }

            Board.ResetCells();
            TurnIndex = 0;
            Mode = mode;
            AssignColorToPlayers(mode);
            PlayerTurn = PlayerColor.WHITE; // White starts
            PrevMove = null;
            IsGameRunning = true;
            while (IsGameRunning)
            {
                var status = GetStatus();
                if (status == GameStatus.NOT_FINISHED)
                {
                    if (TurnIndex > 0)
                        Console.WriteLine($"Turn: {TurnIndex}. {ColorToString(PlayerTurn)}\n");
                    else
                    {
                        Console.WriteLine($"Game mode: {GameModeToString(mode)}\n");
                        Console.WriteLine(Board.ToString());
                        Console.WriteLine($"Turn: {++TurnIndex}. {ColorToString(PlayerTurn)}\n");
                    }
                        

                    RequestMove();
                    Console.WriteLine(Board.ToString());
                    Console.WriteLine($"Move: {PrevMove}\n");
                }
                else
                {
                    try
                    {
                        EndGame();
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }
        }

        public GameStatus CheckBoardRows()
        {
            for (int i = 0; i < Board.BoardSize; i++)
            {
                var row = new string(Board.Cells.ElementAt(i));
                if (row.Contains(WHITE_WINNER_STATE))
                    return GameStatus.WHITE_WON;
                else if (row.Contains(BLACK_WINNER_STATE))
                    return GameStatus.BLACK_WON;
            }
            return GameStatus.NOT_FINISHED;
        }

        public GameStatus CheckBoardCols()
        {
            for (int i = 0; i < Board.BoardSize; i++)
            {
                string col = "";
                for (int j = 0; j < Board.BoardSize; j++)
                {
                    col += Board.Cells.ElementAt(j)[i];
                }
                if (col.Contains(WHITE_WINNER_STATE))
                    return GameStatus.WHITE_WON;
                else if (col.Contains(BLACK_WINNER_STATE))
                    return GameStatus.BLACK_WON;
            }
            return GameStatus.NOT_FINISHED;
        }

        public GameStatus CheckBoardDiagonals()
        {
            var diagonalCells = new Coordinate[2];
            diagonalCells[0] = new Coordinate();
            diagonalCells[1] = new Coordinate(0, Board.MinSize - 1);
            var diagonals = new string[2];
            // dividing board into 5x5 squares when checking diagonals
            for (int i = 0; i < Board.BoardSize - MIN_BOARD_SIZE + 1; i++)
            {
                // go down
                if (i != 0)
                {
                    diagonalCells[0].Y++;
                    diagonalCells[1].Y++;
                }
                for (int j = 0; j < Board.BoardSize - MIN_BOARD_SIZE + 1; j++)
                {
                    diagonals[0] = "";
                    diagonals[1] = "";
                    // go right
                    if (j == 0)
                    {
                        diagonalCells[0].X = 0;
                        diagonalCells[1].X = 0;
                    }
                    else
                    {
                        diagonalCells[0].X++;
                        diagonalCells[1].X++;
                    }

                    for (int k = 0; k < Board.MinSize; k++)
                    {
                        diagonals[0] += Board.Cells.ElementAt(diagonalCells[0].Y + k)[diagonalCells[0].X + k];
                        diagonals[1] += Board.Cells.ElementAt(diagonalCells[1].Y - k)[diagonalCells[1].X + k];
                    }

                    foreach (var diag in diagonals)
                    {
                        if (diag.Contains(WHITE_WINNER_STATE))
                            return GameStatus.WHITE_WON;
                        else if (diag.Contains(BLACK_WINNER_STATE))
                            return GameStatus.BLACK_WON;
                    }
                }
            }
            return GameStatus.NOT_FINISHED;
        }

        public GameStatus GetStatus()
        {
            Task<GameStatus>[] taskArray = {
                Task<GameStatus>.Factory.StartNew(() => CheckBoardRows()),
                Task<GameStatus>.Factory.StartNew(() => CheckBoardCols()),
                Task<GameStatus>.Factory.StartNew(() => CheckBoardDiagonals())
            };

            foreach (var task in taskArray)
            {
                var res = task.Result;
                if (res != GameStatus.NOT_FINISHED)
                {
                    return res;
                }
            }

            return Board.IsFilled() ? GameStatus.DRAW : GameStatus.NOT_FINISHED;
        }


        public void EndGame()
        {
            var status = GetStatus();
            if (status == GameStatus.NOT_FINISHED)
            {
                Console.Error.WriteLine("Game can not be ended, because it has not yet finished!");
                return;
            }

            try
            {
                string gameResult = GameStatusToString(GetStatus());
                Console.WriteLine($"{gameResult}!");
                IsGameRunning = false;
                TurnIndex = -1;
                var task = Task.Run( async () => await Reporter.SaveGameToFileAsync());
                task.Wait();
            } 
            catch (Exception)
            {
                throw;
            }
        }
    }
}