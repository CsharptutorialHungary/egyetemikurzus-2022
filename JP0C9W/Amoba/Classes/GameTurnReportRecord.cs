using Amoba.Interfaces;

namespace Amoba.Classes
{
    public record class GameTurnReportRecord //: IGameTurnReport
    {
        public int TurnIndex { get; init; }
        public GameStatus GameStatus { get; init; }
        public IEnumerable<char[]> GameBoardStatus { get; init; }
        public BoardCell Move { get; init; }
        public GameTurnReportRecord(int turnIndex, GameStatus gameStatus, IEnumerable<char[]> gameBoardStatus, BoardCell move) 
        {
            TurnIndex = turnIndex;
            GameStatus = gameStatus;
            GameBoardStatus = gameBoardStatus;
            Move = move;
        }

        public override string ToString()
        {
            string res = $"Turn: {TurnIndex}.\n\nMove: {Move}\n\n";
            res += Board.BoardCellsToString(GameBoardStatus);
            return res + "\n";
        }
    }
}
