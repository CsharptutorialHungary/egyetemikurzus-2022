namespace Amoba.Interfaces
{
    public interface IBoard
    {
        int MinSize { get; }
        int MaxSize { get; }
        char EmptyCell { get; }
        int BoardSize { get; }
        char[][] Cells { get; }
        void SetCell(int rowIndex, int colIndex, char symbol);
        void ResetCells();
        bool IsFilled();
    }
}
