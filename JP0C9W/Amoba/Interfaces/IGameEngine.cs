namespace Amoba.Interfaces
{
    public enum GameStatus
    {
        WHITE_WON = 0,
        BLACK_WON = 1,
        DRAW = 2,
        NOT_FINISHED = 3
    }

    public enum GameMode
    {
        REAL_VS_REAL = 0,
        REAL_VS_AI = 1,
        AI_VS_AI = 2
    }
    public interface IGameEngine
    {
        IBoard<char> Board { get; }
        IPlayer[] Players { get; }
        PlayerColor PlayerTurn { get; }
        public GameMode? Mode { get; }
        int TurnIndex { get; }
        IBoardCell? PrevMove { get; }
        IGameReporter Reporter { get; }
        void StartNewGame(GameMode mode);
        GameStatus GetStatus();
        void EndGame();
        void AssignColorToPlayers(GameMode mode);
        GameStatus CheckBoardRows();
        GameStatus CheckBoardCols();
        GameStatus CheckBoardDiagonals();

    }
}
