using Amoba.Classes;

namespace Amoba.Interfaces
{
    public interface IGameTurnReport
    {
        int TurnIndex { get; }
        IEnumerable<char[]> GameBoardStatus { get; }
        GameStatus GameStatus { get; }
        BoardCell Move { get; }
    }
}
