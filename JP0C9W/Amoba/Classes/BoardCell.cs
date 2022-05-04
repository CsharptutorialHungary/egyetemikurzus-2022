using Amoba.Interfaces;

namespace Amoba.Classes
{
    public record class BoardCell : IBoardCell
    {
        public ICoordinate Coordinate { get; init; }
        public BoardCellValue Value { get; init; }
        public BoardCell(int x, int y, BoardCellValue value)
        {
            Coordinate = new RecordCoordinate(x < 0 ? 0 : x, y < 0 ? 0 : y);
            Value = value;
        }
        public BoardCell(int x) : this(x, 0, BoardCellValue.EMPTY) { }
        public BoardCell(BoardCellValue value) : this(0, 0, value) { }
        public BoardCell() : this(0, 0, BoardCellValue.EMPTY) { }
        public BoardCell(ICoordinate coordinate, BoardCellValue value)
        {
            Coordinate = new RecordCoordinate(coordinate.X < 0 ? 0 : coordinate.X, coordinate.Y < 0 ? 0 : coordinate.Y);
            Value = value;
        }
        public BoardCell(ICoordinate coordinate) : this(coordinate, BoardCellValue.EMPTY) { }

        public override string ToString()
        {
            return $"Color: {Value}, Row: {Coordinate.Y + 1}, Column: {Coordinate.X + 1}";
        }
    }
}
