using Amoba.Interfaces;
using System.Text.Json;

namespace Amoba.Classes
{
    public class GameReporter : IGameReporter
    {
        public GameReportRecord GameReport { get; set; }
        public GameReporter(GameMode gameMode)
        {
            GameReport = new GameReportRecord(gameMode, new List<GameTurnReportRecord>());
        }
        public GameReporter()
        {
            GameReport = new GameReportRecord();
        }

        public async Task LoadGameFromFileAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The given saved game file ({filePath}) doesn't exist!");
            }

            try
            {
                using var stream = new StreamReader(filePath);
                string json = await stream.ReadToEndAsync();
                var res = JsonSerializer.Deserialize<GameReportRecord>(json);
                if (res != null && res.GameMode != null && res.GameTurnReports != null)
                {
                    _ = GameEngine.GameModeToString(res.GameMode.Value);
                    GameReport = res;
                }
                else
                {
                    throw new Exception("Game file content is invalid!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task ReplayGameAsync(string filePath, int pauseBetWeenTurnsInMs = 0)
        {
            try
            {
                await LoadGameFromFileAsync(filePath);
                GameReport.Replay(pauseBetWeenTurnsInMs);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> SaveGameToFileAsync()
        {
            try
            {
                var currentDate = DateTime.Now;
                string path = Directory.GetCurrentDirectory() + $@"\Amoba_{currentDate.Year}_{currentDate.Month}_{currentDate.Day}_{currentDate.Hour}_{currentDate.Minute}_{currentDate.Millisecond}.json";
                using var fileStream = File.Create(path);
                await JsonSerializer.SerializeAsync(
                    fileStream,
                    GameReport,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true,
                    }
                );
                return path;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveTurn(GameTurnReportRecord gameTurnReport)
        {
            GameReport.GameTurnReports.Add(gameTurnReport);
        }
    }
}
