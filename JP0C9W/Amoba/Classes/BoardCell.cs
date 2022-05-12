using Amoba.Interfaces;
using System.Text.Json.Serialization;

namespace Amoba.Classes
{
    public record class BoardCell : IBoardCell
    {
        public int X { get; init; }
        public int Y { get; init; }
        public BoardCellValue Value { get; init; }

        [JsonConstructor]
        public BoardCell(int x, int y, BoardCellValue value)
        {
            X = x < 0 ? 0 : x;
            Y = y < 0 ? 0 : y;
            Value = value;
        }
        public BoardCell(int x) : this(x, 0, BoardCellValue.EMPTY) { }
        public BoardCell(BoardCellValue value) : this(0, 0, value) { }
        public BoardCell() : this(0, 0, BoardCellValue.EMPTY) { }
        public BoardCell(IBoardCell boardCell)
        {
            X = boardCell.X;
            Y = boardCell.Y;
            Value = boardCell.Value;
        }

        public override string ToString()
        {
            return $"Color: {Value}, Row: {Y + 1}, Column: {X + 1}";
        }

        public BoardCell Copy()
        {
            return new BoardCell(X, Y, Value);
        }
    }
}
