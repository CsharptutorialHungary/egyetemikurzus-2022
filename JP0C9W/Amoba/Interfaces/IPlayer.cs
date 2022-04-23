namespace Amoba.Interfaces
{
    public enum Color
    {
        WHITE = 'O',
        BLACK = 'X'
    }
    public interface IPlayer
    {
        IAction SetAction(IBoard board, ICell prevMove, Color playerColor); 
    }
}
