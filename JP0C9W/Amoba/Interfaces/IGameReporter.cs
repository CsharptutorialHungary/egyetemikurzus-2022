using Amoba.Classes;

namespace Amoba.Interfaces 
{
    public interface IGameReporter
    {
        GameReportRecord GameReport { get; }
        Task ReplayGameAsync(string fileName);
        Task LoadGameFromFileAsync(string fileName);
        Task SaveGameToFileAsync();
        void SaveTurn(GameTurnReportRecord gameTurnReport);
    }
}
