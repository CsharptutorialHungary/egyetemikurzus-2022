namespace Amoba.Interfaces
{
    public interface IBoard<T>
    {
        int MinSize { get; }
        int MaxSize { get; }
        int BoardSize { get; }
        IEnumerable<T[]> Cells { get; }
        void SetCell(IBoardCell cell);
        void SetCell(int x, int y, BoardCellValue value);
        void ResetCells();
        bool IsFilled();
        IEnumerable<T[]> CopyCells();
    }
}
