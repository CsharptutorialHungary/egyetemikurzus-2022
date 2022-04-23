using Amoba.Interfaces;

namespace Amoba.Classes
{
    public class Board : IBoard
    {
        public int MinSize { get; }
        public int MaxSize { get; }
        public char EmptyCell { get; }
        
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
        public char[][] Cells { get; set; }
        public Board(int minSize, int maxSize, int boardSize, char emptyCell)
        {
            MinSize = minSize;
            MaxSize = maxSize;
            BoardSize = boardSize;
            EmptyCell = emptyCell;
            Cells = FillCells(EmptyCell);
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
            Cells = FillCells(EmptyCell);
        }

        public void SetCell(int rowIndex, int colIndex, char symbol)
        {
            if (0 <= rowIndex && rowIndex < BoardSize && 0 <= colIndex && colIndex < BoardSize)
                Cells[rowIndex][colIndex] = symbol;
            else
                throw new ArgumentException("Invalid cell!");
        }

        public override string ToString()
        {
            string formattedBoard = "";
            int rowNumTextOffset = (int)Math.Log10(BoardSize);
            int colNumTextOffset = (int)Math.Log10(BoardSize);
            char[][] colNumText = new char[colNumTextOffset][];
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (j == 0)
                    {
                        for (int k = 0; k < rowNumTextOffset - Math.Log10(i + 1); k++)
                        {
                            formattedBoard += ' ';
                        }
                        formattedBoard += $"{i + 1}  ";
                    }
                    formattedBoard += Cells[i][j];
                    formattedBoard += j != BoardSize - 1 ? " " : '\n';
                }
            }
            return formattedBoard;
        }

        public bool IsFilled()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                var row = new string(Cells[i]);
                if (row.Contains(EmptyCell))
                    return false;
            }
            return true;
        }
    }
}
