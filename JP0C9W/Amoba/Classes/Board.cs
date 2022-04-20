using Amoba.Interfaces;

namespace Amoba.Classes
{
    public class Board : IBoard
    {
        private readonly int MIN_SIZE = 5; 
        private readonly int MAX_SIZE = 100;
        private readonly char EMPTY_CELL = '#';
        private int _rowSize;
        public int RowSize
        {
            get
            {
                return _rowSize;
            }
            private set 
            {
                if (value > MAX_SIZE)
                {
                    _rowSize = MAX_SIZE;
                } else
                {
                    _rowSize = MIN_SIZE > value ? MIN_SIZE : value;
                }
            }
        }
        private int _colSize;
        public int ColSize
        {
            get
            {
                return _colSize;
            }
            private set
            {
                if (value > MAX_SIZE)
                {
                    _colSize = MAX_SIZE;
                }
                else
                {
                    _colSize = MIN_SIZE > value ? MIN_SIZE : value;
                }
            }
        }
        public char[,] Cells { get; set; }
        public Board(int rowSize, int colSize)
        {
            RowSize = rowSize;
            ColSize = colSize;
            Cells = GenerateCells(EMPTY_CELL);
        }

        private char[,] GenerateCells(char fillChar)
        {
            var result = new char[RowSize, ColSize];
            for (int i = 0; i < RowSize; i++)
            {
                for (int j = 0; j < ColSize; j++)
                {
                    result[i, j] = fillChar;
                }
            }
            return result;   
        }

        public void Reset()
        {
            Cells = GenerateCells(EMPTY_CELL);
        }

        public void SetMove(int rowNum, int colNum, Color playerColor)
        {
            if (MIN_SIZE < rowNum && rowNum < RowSize && MIN_SIZE < colNum && colNum < ColSize)
            {
                if (Cells[rowNum, colNum] == EMPTY_CELL)
                {
                    Cells[rowNum, colNum] = (char)playerColor;
                } else
                {
                    throw new Exception("Cell is already taken!");
                }
                
            }
            else
            {
                throw new ArgumentException("Invalid cell!");
            }
        }

        public override string ToString()
        {
            string formattedBoard = "";
            for (int i = 0; i < RowSize; i++)
            {
                for (int j = 0; j < ColSize; j++)
                {
                    formattedBoard += Cells[i, j];
                    formattedBoard += j != ColSize - 1 ? " " : '\n';
                }
            }
            return formattedBoard;
        }
    }
}
