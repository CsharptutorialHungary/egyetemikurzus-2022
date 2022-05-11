using Amoba.Interfaces;
using System.Text.Json.Serialization;

namespace Amoba.Classes
{
    public record class GameTurnReportRecord : IGameTurnReport
    {
        private int _turnIndex;
        public int TurnIndex {
            get
            {
                return _turnIndex;
            } 
            init
            {
                _turnIndex = value <= 0 ? 1 : value;
            }
        }

        public GameStatus GameStatus { get; init; }
        public IEnumerable<char[]> GameBoardStatus { get; init; }
        public BoardCell Move { get; init; }

        [JsonConstructor]
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
