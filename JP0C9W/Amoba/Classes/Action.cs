using Amoba.Interfaces;

namespace Amoba.Classes
{
    public class Action : IAction
    {
        public ICell SelectedCell { get; }
        public Color PlayerColor { get; }
        public Action(ICell cell, Color playerColor) {
            SelectedCell = cell;
            PlayerColor = playerColor;
        }
    }
}
