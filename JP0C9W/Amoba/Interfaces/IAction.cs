namespace Amoba.Interfaces
{
    public interface IAction
    {
        ICell SelectedCell { get; }
        Color PlayerColor { get; }
    }
}
