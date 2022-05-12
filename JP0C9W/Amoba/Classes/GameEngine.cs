using Amoba.Interfaces;

namespace Amoba.Classes
{
    public class GameEngine : IGameEngine
    {
        public static readonly Random RANDOM = new();
        public static readonly string PLAY_MODE = "play";
        public static readonly string REPLAY_MODE = "replay";
        private readonly string WHITE_WINNER_STATE;
        private readonly string BLACK_WINNER_STATE;
        private IPlayer[] _players;
        private IBoard<char> _board;
        public IGameReporter Reporter { get; init; }
        public GameMode? Mode { get; private set; }
        public int TurnIndex { get; private set; }
        public IPlayer[] Players
        {
            get
            {
                var copy = new IPlayer[_players.Length];
                _players.CopyTo(copy, 0);
                return copy;
            }
            private set
            {
                _players = value;
            }
        }
        public PlayerColor PlayerTurn { get; private set; }
        public bool IsGameRunning { get; private set; }
        public IBoard<char> Board
        {
            get
            {
                return new Board(_board);
            }
            private set
            {
                _board = value;
            }
        }
        public IBoardCell? PrevMove { get; private set; }

        public static bool IsValidEngineMode(string mode)
        {
            return mode.ToLower() == PLAY_MODE || mode.ToLower() == REPLAY_MODE;
        }

        public static bool IsMoveValid(IBoardCell cell, IBoard<char> board)
        {
            return 0 <= cell.Y && cell.Y < board.BoardSize && 0 <= cell.X && cell.X < board.BoardSize && board.Cells.ElementAt(cell.Y)[cell.X] == Classes.Board.EMPTY_CELL;
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
                _ => throw new ArgumentException("Invalid game status!"),
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
                _ => throw new ArgumentException("Invalid game status!"),
            };
        }

        public static string GameModeToString(GameMode gameMode)
        {
            return gameMode switch
            {
                GameMode.REAL_VS_REAL => "Real vs Real",
                GameMode.REAL_VS_AI => "Real vs AI",
                GameMode.AI_VS_AI => "AI vs AI",
                _ => throw new ArgumentException("Invalid game mode!"),
            };
        }

        public static GameMode StringToGameMode(string gameMode)
        {
            return gameMode switch
            {
                "Real vs Real" => GameMode.REAL_VS_REAL,
                "Real vs AI" => GameMode.REAL_VS_AI,
                "AI vs AI" => GameMode.AI_VS_AI,
                _ => throw new ArgumentException("Invalid game mode!"),
            };
        }

        public static GameMode IntToGameMode(int gameModeCode)
        {
            return gameModeCode switch
            {
                0 => GameMode.REAL_VS_REAL,
                1 => GameMode.REAL_VS_AI,
                2 => GameMode.AI_VS_AI,
                _ => throw new ArgumentException("Invalid game mode!"),
            };
        }

        public GameEngine(IGameReporter gameReporter, int boardSize)
        {
            Reporter = gameReporter;
            WHITE_WINNER_STATE = new((char)BoardCellValue.WHITE, Classes.Board.MIN_BOARD_SIZE);
            BLACK_WINNER_STATE = new((char)BoardCellValue.BLACK, Classes.Board.MIN_BOARD_SIZE);
            _board = new Board(boardSize);
            IsGameRunning = false;
            TurnIndex = -1;
            _players = new IPlayer[2];
            PlayerTurn = PlayerColor.WHITE;
        }

        private void RequestMove()
        {
            if (!IsGameRunning)
            {
                Console.WriteLine("Can't request move, because game is not running!");
                return;
            }

            try
            {
                IPlayer? player = _players[(int)PlayerTurn];
                if (player == null)
                {
                    Console.WriteLine("Players aren't initialized!");
                    return;
                }
                var action = player.GetMove(_board, PrevMove);
                while (!IsMoveValid(action, _board))
                {
                    action = player.GetMove(_board, PrevMove);
                }
                PrevMove = action;
                _board.SetCell(action);
                PlayerTurn = (PlayerColor)(1 - (int)PlayerTurn);
                // save turn
                Reporter.SaveTurn(new GameTurnReportRecord(TurnIndex++, GetStatus(), _board.CopyCells(), new BoardCell(action)));
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
                Console.WriteLine("Can't assign colors to players, because a game is already running!");
                return;
            }

            int coinFlip = RANDOM.Next(0, 2);
            switch (mode)
            {
                case GameMode.REAL_VS_AI:
                    _players[coinFlip] = new ConsolePlayer((PlayerColor)coinFlip);
                    _players[1 - coinFlip] = new RandomPlayer((PlayerColor)(1 - coinFlip), _board);
                    break;
                case GameMode.AI_VS_AI:
                    _players[coinFlip] = new RandomPlayer((PlayerColor)coinFlip, _board);
                    _players[1 - coinFlip] = new RandomPlayer((PlayerColor)(1 - coinFlip), _board);
                    break;
                default:
                    _players[coinFlip] = new ConsolePlayer((PlayerColor)coinFlip);
                    _players[1 - coinFlip] = new ConsolePlayer((PlayerColor)(1 - coinFlip));
                    break;
            }
        }

        public void StartNewGame(GameMode mode)
        {
            if (IsGameRunning)
            {
                Console.WriteLine("A new game cannot be started, because a game is already running!");
                return;
            }

            _board.ResetCells();
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
                    {
                        Console.WriteLine($"Turn: {TurnIndex}. {ColorToString(PlayerTurn)}\n");
                    }
                    else
                    {
                        Console.WriteLine($"Game mode: {GameModeToString(mode)}\n");
                        Console.WriteLine(_board.ToString());
                        Console.WriteLine($"Turn: {++TurnIndex}. {ColorToString(PlayerTurn)}\n");
                    }


                    RequestMove();
                    Console.WriteLine(_board.ToString());
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
            var cells = _board.Cells;
            for (int i = 0; i < _board.BoardSize; i++)
            {
                var row = new string(cells.ElementAt(i));
                if (row.Contains(WHITE_WINNER_STATE))
                {
                    return GameStatus.WHITE_WON;
                }
                else if (row.Contains(BLACK_WINNER_STATE))
                {
                    return GameStatus.BLACK_WON;
                }
            }
            return GameStatus.NOT_FINISHED;
        }

        public GameStatus CheckBoardCols()
        {
            var cells = _board.Cells;
            for (int i = 0; i < _board.BoardSize; i++)
            {
                string col = "";
                for (int j = 0; j < _board.BoardSize; j++)
                {
                    col += cells.ElementAt(j)[i];
                }
                if (col.Contains(WHITE_WINNER_STATE))
                {
                    return GameStatus.WHITE_WON;
                }
                else if (col.Contains(BLACK_WINNER_STATE))
                {
                    return GameStatus.BLACK_WON;
                }
            }
            return GameStatus.NOT_FINISHED;
        }

        public GameStatus CheckBoardDiagonals()
        {
            var diagonalCells = new Coordinate[2];
            diagonalCells[0] = new Coordinate();
            diagonalCells[1] = new Coordinate(0, _board.MinSize - 1);
            var diagonals = new string[2];
            var cells = _board.Cells;
            // dividing board into 5x5 squares when checking diagonals
            for (int i = 0; i < _board.BoardSize - Classes.Board.MIN_BOARD_SIZE + 1; i++)
            {
                // go down
                if (i != 0)
                {
                    diagonalCells[0].Y++;
                    diagonalCells[1].Y++;
                }
                for (int j = 0; j < _board.BoardSize - Classes.Board.MIN_BOARD_SIZE + 1; j++)
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

                    for (int k = 0; k < _board.MinSize; k++)
                    {
                        diagonals[0] += cells.ElementAt(diagonalCells[0].Y + k)[diagonalCells[0].X + k];
                        diagonals[1] += cells.ElementAt(diagonalCells[1].Y - k)[diagonalCells[1].X + k];
                    }

                    foreach (var diag in diagonals)
                    {
                        if (diag.Contains(WHITE_WINNER_STATE))
                        {
                            return GameStatus.WHITE_WON;
                        }
                        else if (diag.Contains(BLACK_WINNER_STATE))
                        {
                            return GameStatus.BLACK_WON;
                        }
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

            return _board.IsFilled() ? GameStatus.DRAW : GameStatus.NOT_FINISHED;
        }


        public void EndGame()
        {
            if (!IsGameRunning)
            {
                Console.WriteLine("Game is not running!");
                return;
            }

            var status = GetStatus();
            if (status == GameStatus.NOT_FINISHED && IsGameRunning)
            {
                Console.WriteLine("Game can not be ended, because it has not yet finished!");
                return;
            }

            try
            {
                string gameResult = GameStatusToString(GetStatus());
                Console.WriteLine($"{gameResult}!");
                IsGameRunning = false;
                TurnIndex = -1;
                var task = Task.Run(async () => _ = await Reporter.SaveGameToFileAsync());
                task.Wait();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}