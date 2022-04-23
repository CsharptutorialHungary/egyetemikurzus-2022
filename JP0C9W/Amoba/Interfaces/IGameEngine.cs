using Amoba.Classes;

namespace Amoba.Interfaces
{
    public interface IGameEngine
    {
        IBoard Board { get; }
        void StartNewGame();
        void RequestMove();
        bool IsMoveValid(int rowIndex, int colIndex);
        GameStatus GetStatus();
    }
}
