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
                throw new FileNotFoundException($"The given saved game file ({filePath}) doesn't exist!");

            try {
                using var stream = new StreamReader(filePath);
                string json = await stream.ReadToEndAsync();
                var res = JsonSerializer.Deserialize<GameReportRecord>(json);
                if (res != null)
                    GameReport = res;
                else
                    throw new Exception("File is invalid!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task ReplayGameAsync(string filePath)
        {
            try
            {
                await LoadGameFromFileAsync(filePath);
                GameReport.Replay(500);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SaveGameToFileAsync()
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
