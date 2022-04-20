namespace Amoba.Interfaces
{
    public interface IBoard
    {
        int RowSize { get; }
        int ColSize { get; }
        char[,] Cells { get; }
        void SetMove(int rowNum, int colNum, char playerSymbol);
        void ResetBoard();
    }
}
