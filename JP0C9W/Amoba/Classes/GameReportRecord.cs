using Amoba.Interfaces;
using System.Text.Json.Serialization;

namespace Amoba.Classes
{
    public record class GameReportRecord : IGameReport
    {
        public GameMode? GameMode { get; init; }
        public ICollection<GameTurnReportRecord> GameTurnReports { get; init; }

        [JsonConstructor]
        public GameReportRecord(GameMode? gameMode, ICollection<GameTurnReportRecord> gameTurnReports)
        {
            GameMode = gameMode;
            GameTurnReports = gameTurnReports;
        }
        public GameReportRecord(GameMode? gameMode = null) : this(gameMode, new List<GameTurnReportRecord>()) { }

        public void Replay(int timeout)
        {
            if (timeout < 0)
                throw new ArgumentException("Timeout must be greater than or equal to 0!");

            for (int i = 0; i < GameTurnReports.Count; i++)
            {
                if (i == 0 && GameMode.HasValue)
                    Console.WriteLine($"Game mode: {GameEngine.GameModeToString(GameMode.Value)}\n");

                var turnReport = GameTurnReports.ElementAt(i);
                Console.WriteLine(turnReport);

                if (i == GameTurnReports.Count - 1)
                    Console.WriteLine($"Game result: {GameEngine.GameStatusToString(turnReport.GameStatus)}");
                else
                    Thread.Sleep(timeout);
            }
        }
    }
}
