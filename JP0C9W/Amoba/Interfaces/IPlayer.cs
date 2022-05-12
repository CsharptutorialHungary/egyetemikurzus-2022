namespace Amoba.Interfaces
{
    public enum PlayerColor
    {
        WHITE = 0,
        BLACK = 1
    }
    public enum PlayerType
    {
        AI = 0,
        REAL = 1,
    }
    public interface IPlayer
    {
        PlayerColor Color { get; }
        PlayerType Type { get; }
        IBoardCell GetMove(IBoard<char> board, IBoardCell? prevMove);
    }
}
