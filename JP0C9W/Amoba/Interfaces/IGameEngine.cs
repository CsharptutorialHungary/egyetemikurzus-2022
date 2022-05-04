using Amoba.Classes;

namespace Amoba.Interfaces
{
    public interface IGameEngine
    {
        IBoard<char> Board { get; }
        IPlayer[] Players { get; }
        PlayerColor PlayerTurn { get; }
        public IBoardCell? PrevMove { get; }
        void StartNewGame(GameMode mode);
        void RequestMove();
        GameStatus GetStatus();
    }
}
