﻿using Amoba.Interfaces;

namespace Amoba.Classes
{
    public class Board : IBoard<char>
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
        public IEnumerable<char[]> Cells { get; set; }

        public static string BoardCellsToString(IEnumerable<char[]> cells)
        {
            string formattedBoard = "";
            if (!cells.Any())
                throw new ArgumentException("Can't convert cells to string, bacause cells argument is empty!");

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

        public void SetCell(IBoardCell cell)
        {
            if (0 <= cell.Y && cell.Y < BoardSize && 0 <= cell.X && cell.X < BoardSize)
                Cells.ElementAt(cell.Y)[cell.X] = (char)cell.Value;
            else
                throw new ArgumentException("Invalid cell!");
        }

        public override string ToString()
        {
            return BoardCellsToString(Cells);
        }

        public bool IsFilled()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                var row = new string(Cells.ElementAt(i));
                if (row.Contains(EmptyCell))
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
                for (int j = 0; j < BoardSize; j++)
                {
                    res[i][j] = Cells.ElementAt(i)[j];
                }
            }
            return res;
        } 
    }
}