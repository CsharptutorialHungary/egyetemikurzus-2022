using Amoba.Interfaces;

namespace Amoba.Classes
{
    public enum GameStatus
    {
        WHITE_WON = 0,
        BLACK_WON = 1,
        DRAW = 2,
        NOT_FINISHED = 3
    }
    public enum GameMode
    {
        REAL_VS_REAL = 0,
        REAL_VS_AI = 1,
        AI_VS_AI = 2,
    }
    public class GameEngine : IGameEngine
    {
        private const int MIN_BOARD_SIZE = 5;
        private const int MAX_BOARD_SIZE = 100;
        private readonly string WHITE_WINNER_STATE;
        private readonly string BLACK_WINNER_STATE;
        public IPlayer[] Players { get; private set; }
        public PlayerColor PlayerTurn { get; private set; }
        public bool IsGameRunning { get; private set; }
        public IBoard<char> Board { get; private set; }
        public IBoardCell? PrevMove { get; private set; }
        public static bool IsMoveValid(IBoardCell cell, IBoard<char> board)
        {
            return 0 <= cell.Coordinate.Y && cell.Coordinate.Y < board.BoardSize && 0 <= cell.Coordinate.X && cell.Coordinate.X < board.BoardSize && board.Cells.ElementAt(cell.Coordinate.Y)[cell.Coordinate.X] == board.EmptyCell;
        }
        public GameEngine(int boardSize) {
            WHITE_WINNER_STATE = new((char)BoardCellValue.WHITE, MIN_BOARD_SIZE);
            BLACK_WINNER_STATE = new((char)BoardCellValue.BLACK, MIN_BOARD_SIZE);
            Board = new Board(MIN_BOARD_SIZE, MAX_BOARD_SIZE, boardSize, (char)BoardCellValue.EMPTY);
            IsGameRunning = false;
            Players = new IPlayer[2];
            PlayerTurn = PlayerColor.WHITE;
        }

        public static BoardCellValue ColorToValue(PlayerColor Color)
        {
            return Color == PlayerColor.WHITE ? BoardCellValue.WHITE : BoardCellValue.BLACK;
        }

        public void StartNewGame(GameMode mode)
        {
            Board.ResetCells();
            IsGameRunning = true;
            var rnd = new Random();
            switch (mode)
            {
                case GameMode.REAL_VS_REAL:
                    Players[0] = new ConsolePlayer((PlayerColor)rnd.Next(0, 1));
                    Players[1] = new ConsolePlayer((PlayerColor)(1 - (int)Players[0].Color));
                    break;
                case GameMode.REAL_VS_AI:
                    Players[0] = new ConsolePlayer((PlayerColor)rnd.Next(0, 1));
                    Players[1] = new RandomPlayer((PlayerColor)(1 - (int)Players[0].Color), Board);
                    break;
                case GameMode.AI_VS_AI:
                    Players[0] = new RandomPlayer((PlayerColor)rnd.Next(0, 1), Board);
                    Players[1] = new RandomPlayer((PlayerColor)(1 - (int)Players[0].Color), Board);
                    break;
                default:
                    Console.WriteLine("Unexpected game mode!");
                    break;
            }
            PlayerTurn = PlayerColor.WHITE;
            PrevMove = null;
        }

        public void RequestMove()
        {
            var player = Players[(int)PlayerTurn];
            var action = player.GetMove(Board, PrevMove);
            while (!IsMoveValid(action, Board))
            {
                action = player.GetMove(Board, PrevMove);
            }
            Console.WriteLine("Player's turn: " + ColorToValue(player.Color));
            PrevMove = action;
            Board.SetCell(action);
            PlayerTurn = (PlayerColor)(1 - (int)PlayerTurn);
        }

        public GameStatus GetStatus()
        {
            for (int i = 0; i < Board.BoardSize; i++)
            {
                var row = new string(Board.Cells.ElementAt(i));
                if (row.Contains(WHITE_WINNER_STATE))
                    return GameStatus.WHITE_WON;
                else if (row.Contains(BLACK_WINNER_STATE))
                    return GameStatus.BLACK_WON;
            }

            var strList = new List<string>();
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

            strList.Clear();
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

            return Board.IsFilled() ? GameStatus.DRAW : GameStatus.NOT_FINISHED;
        }


        public void EndGame()
        {
            switch (GetStatus())
            {
                case GameStatus.DRAW:
                    Console.Write("Draw");
                    break;
                case GameStatus.BLACK_WON:
                    Console.Write("X won");
                    break;
                case GameStatus.WHITE_WON:
                    Console.Write("O won");
                    break;
                default:
                    throw new Exception("Game has not yet finished!");
            }
            IsGameRunning = false;
        }
    }
}