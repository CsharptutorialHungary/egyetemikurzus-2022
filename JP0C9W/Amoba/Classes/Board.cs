using Amoba.Interfaces;

namespace Amoba.Classes
{
    public class Board : IBoard<char>
    {
        public static readonly int MIN_BOARD_SIZE = 5;
        public static readonly int MAX_BOARD_SIZE = 100;
        public static readonly char EMPTY_CELL = (char)BoardCellValue.EMPTY;
        private int _minSize;
        public int MinSize {
            get
            {
                return _minSize;
            }
            init
            {
                if (value > MAX_BOARD_SIZE)
                {
                    _minSize = MAX_BOARD_SIZE;
                }
                else
                {
                    _minSize = MIN_BOARD_SIZE > value ? MIN_BOARD_SIZE : value;
                }
            } 
        }
        private int _maxSize;
        public int MaxSize
        {
            get
            {
                return _maxSize;
            }
            init
            {
                if (value > MAX_BOARD_SIZE)
                {
                    _maxSize = MAX_BOARD_SIZE;
                }
                else
                {
                    _maxSize = MIN_BOARD_SIZE > value ? MIN_BOARD_SIZE : value;
                }
            }
        }
        private int _boardSize;
        public int BoardSize
        {
            get
            {
                return _boardSize;
            }
            private set
            {
                if (value > MaxSize)
                {
                    _boardSize = MaxSize;
                }
                else
                {
                    _boardSize = MinSize > value ? MinSize : value;
                }
            }
        }
        private IEnumerable<char[]> _cells; 
        public IEnumerable<char[]> Cells
        {
            get
            {
                return CopyCells(); // Only copy access
            }
            private set
            {
                _cells = value;
            }
        }

        public static string BoardCellsToString(IEnumerable<char[]> cells)
        {
            string formattedBoard = "";
            if (!cells.Any())
                throw new ArgumentException("Can't convert cells to string, bacause cells argument is empty!");
            else if (cells.Count() != cells.ElementAt(0).Length)
                throw new ArgumentException("Board is not symmetrical!");

            int boardSize = cells.Count();
            int rowNumTextOffset = (int)Math.Log10(boardSize);
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (j == 0)
                    {
                        for (int k = 0; k < rowNumTextOffset - Math.Log10(i + 1); k++)
                        {
                            formattedBoard += ' ';
                        }
                        formattedBoard += $"{i + 1}  ";
                    }
                    formattedBoard += cells.ElementAt(i)[j];
                    formattedBoard += j != boardSize - 1 ? " " : '\n';
                }
            }
            return formattedBoard;
        } 

        public Board(IBoard<char> board)
        {
            MinSize = board.MinSize;
            MaxSize = board.MaxSize;
            BoardSize = board.BoardSize;
            _cells = board.CopyCells();
        }
        public Board(int minSize, int maxSize, int boardSize)
        {
            if (maxSize < minSize) 
            {
                MinSize = maxSize;
                MaxSize = minSize;
            } 
            else 
            {
                MinSize = minSize;
                MaxSize = maxSize;
            }
            BoardSize = boardSize;
            _cells = FillCells(EMPTY_CELL);
        }

        public Board(int boardSize)
        {
            MinSize = MIN_BOARD_SIZE;
            MaxSize = MAX_BOARD_SIZE;
            BoardSize = boardSize;
            _cells = FillCells(EMPTY_CELL);
        }

        private char[][] FillCells(char fillChar)
        {
            var result = new char[BoardSize][];
            for (int i = 0; i < BoardSize; i++)
            {
                result[i] = new char[BoardSize];
                for (int j = 0; j < BoardSize; j++)
                {
                    result[i][j] = fillChar;
                }
            }
            return result;   
        }

        public void ResetCells()
        {
            _cells = FillCells(EMPTY_CELL);
        }

        public void SetCell(IBoardCell cell)
        {
            if (0 <= cell.Y && cell.Y < BoardSize && 0 <= cell.X && cell.X < BoardSize)
                _cells.ElementAt(cell.Y)[cell.X] = (char)cell.Value;
            else
                throw new ArgumentException("Invalid cell!");
        }

        public void SetCell(int x, int y, BoardCellValue value)
        {
            SetCell(new BoardCell(x, y, value));
        }

        public override string ToString()
        {
            return BoardCellsToString(_cells);
        }

        public bool IsFilled()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                var row = new string(_cells.ElementAt(i));
                if (row.Contains(EMPTY_CELL))
                    return false;
            }
            return true;
        }

        public IEnumerable<char[]> CopyCells()
        {
            var res = new char[BoardSize][];
            for (int i = 0; i < BoardSize; i++)
            {
                res[i] = new char[BoardSize];
                _cells.ElementAt(i).CopyTo(res[i], 0);
            }
            return res;
        } 
    }
}
