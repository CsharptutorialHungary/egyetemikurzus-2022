namespace Amoba.Interfaces
{
    public enum BoardCellValue
    {
        EMPTY = '#',
        WHITE = 'O',
        BLACK = 'X'
    }
    public interface IBoardCell : ICell<BoardCellValue> { }
}
