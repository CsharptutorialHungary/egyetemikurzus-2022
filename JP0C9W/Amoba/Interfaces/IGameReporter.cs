using Amoba.Classes;

namespace Amoba.Interfaces
{
    public interface IGameReporter
    {
        GameReportRecord GameReport { get; }
        Task ReplayGameAsync(string fileName, int pauseBetWeenTurnsInM);
        Task LoadGameFromFileAsync(string fileName);
        Task<string> SaveGameToFileAsync();
        void SaveTurn(GameTurnReportRecord gameTurnReport);
    }
}
