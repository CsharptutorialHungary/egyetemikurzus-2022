namespace Amoba.Interfaces
{
    public interface IBoard<T>
    {
        int MinSize { get; }
        int MaxSize { get; }
        char EmptyCell { get; }
        int BoardSize { get; }
        IEnumerable<T[]> Cells { get; }
        void SetCell(IBoardCell cell);
        void ResetCells();
        bool IsFilled();
    }
}
