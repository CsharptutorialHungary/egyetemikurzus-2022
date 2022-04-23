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
    public class GameEngine : IGameEngine
    {
        private readonly int MIN_BOARD_SIZE = 5;
        private readonly int MAX_BOARD_SIZE = 100;
        public bool IsGameRunning { get; private set; } 
        public IBoard Board { get; private set; }
        public GameEngine(int boardSize) {
            Board = new Board(MIN_BOARD_SIZE, MAX_BOARD_SIZE, boardSize, '#');
            IsGameRunning = false;
        }

        public void StartNewGame()
        {
            Board.ResetCells();
            IsGameRunning = true;
        }

        public void RequestMove()
        {
            int rowIndex = -1;
            int colIndex = -1;
            bool isValidMove = false;
            while ((colIndex == -1 || rowIndex == -1) && !isValidMove)
            {
                Console.WriteLine("Row: ");
                var inputRowIndex = Console.ReadLine();
                if (!int.TryParse(inputRowIndex, out int tmpRowIndex) || tmpRowIndex <= 0)
                {
                    Console.WriteLine($"{inputRowIndex} is not a valid index!");
                    continue;
                }
                else
                {
                    rowIndex = tmpRowIndex;
                }

                Console.WriteLine("Column: ");
                var inputColIndex = Console.ReadLine();
                if (!int.TryParse(inputColIndex, out int tmpColIndex) || tmpColIndex <= 0)
                {
                    Console.WriteLine($"{inputColIndex} is not a valid index!");
                    continue;
                }
                else
                {
                    colIndex = tmpColIndex;
                }

                isValidMove = IsMoveValid(rowIndex - 1, colIndex - 1);
            }
            try
            {
                Board.SetCell(rowIndex - 1, colIndex - 1, (char)Color.WHITE);
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                RequestMove();
            }
            
        }

        public bool IsMoveValid(int rowIndex, int colIndex)
        {
            return Board != null ? Board.Cells[rowIndex][colIndex] == Board.EmptyCell : false;
        }

        public GameStatus GetStatus()
        {
            for (int i = 0; i < Board.BoardSize; i++)
            {
                var row = new string(Board.Cells[i]);
                if (row.Contains("OOOOO"))
                    return GameStatus.WHITE_WON;
                else if (row.Contains("XXXXX"))
                    return GameStatus.BLACK_WON;
            }

            var strList = new List<string>();
            for (int i = 0; i < Board.BoardSize; i++)
            {
                string col = "";
                for (int j = 0; j < Board.BoardSize; j++)
                {
                    col += Board.Cells[i][j];
                }
                if (col.Contains("OOOOO"))
                    return GameStatus.WHITE_WON;
                else if (col.Contains("XXXXX"))
                    return GameStatus.BLACK_WON;
            }

            strList.Clear();
            var diagonalCells = new Cell[2];
            diagonalCells[0] = new Cell();
            diagonalCells[1] = new Cell(0, Board.MinSize - 1);
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
                    // go left
                    if (j == 0)
                    {
                        diagonalCells[0].X = 0;
                        diagonalCells[1].X = 0;
                    } else
                    {
                        diagonalCells[0].X++;
                        diagonalCells[1].X++;
                    }
                    
                    for (int k = 0; k < Board.MinSize; k++)
                    {
                        diagonals[0] += Board.Cells[diagonalCells[0].Y + k][diagonalCells[0].X + k];
                        diagonals[1] += Board.Cells[diagonalCells[1].Y - k][diagonalCells[1].X + k];
                    }

                    foreach (var diag in diagonals)
                    {
                        Console.WriteLine($"diag: {diag}");
                        if (diag.Contains("OOOOO"))
                            return GameStatus.WHITE_WON;
                        else if (diag.Contains("XXXXX"))
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