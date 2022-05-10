using Amoba.Classes;

namespace Amoba.Interfaces
{
    public interface IGameReport
    {
        GameMode? GameMode { get; }
        ICollection<GameTurnReportRecord> GameTurnReports { get; }
        void Replay(int timeout);
    }
}
