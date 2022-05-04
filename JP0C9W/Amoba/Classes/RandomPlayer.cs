using Amoba.Interfaces;

namespace Amoba.Classes
{
    internal class RandomPlayer : IPlayer
    {
        private readonly Random _rnd;
        private ICollection<IBoardCell> FreeCells;
        public PlayerColor Color { get; set; }
        public PlayerType Type { get; }
        public RandomPlayer(PlayerColor color, IBoard<char> board)
        {
            _rnd = new Random();
            Type = PlayerType.AI;
            Color = color;
            FreeCells = new List<IBoardCell>();
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    if (board.Cells.ElementAt(i)[j] == board.EmptyCell)
                    {
                        FreeCells.Add(new BoardCell(j, i, BoardCellValue.EMPTY));
                    }
                }
            }
        }

        public RandomPlayer(IBoard<char> board) : this(PlayerColor.WHITE, board) { }

        private void ShuffleCollection<T>(ref ICollection<T> col)
        {
            col = col.OrderBy(i => _rnd.Next()).ToList();
        } 

        public IBoardCell GetMove(IBoard<char> board, IBoardCell? prevMove)
        {
            if (FreeCells.Count > 0)
                {
                if (prevMove != null)
                {
                    IBoardCell? prevCell = null;
                    try
                    {
                        prevCell = FreeCells.Single(cell => cell.Coordinate.Y == prevMove.Coordinate.Y && cell.Coordinate.X == prevMove.Coordinate.X);
                    } 
                    catch (Exception)
                    {
                        throw;
                    }

                    if (prevCell != null)
                        FreeCells.Remove(prevCell);
                    else
                        throw new Exception($"Can't find previous move ({prevMove}) on board!");
                }
                ShuffleCollection(ref FreeCells);
                var selectedCell = FreeCells.ElementAt(_rnd.Next(0, FreeCells.Count - 1));
                FreeCells.Remove(selectedCell);
                return new BoardCell(selectedCell.Coordinate.X, selectedCell.Coordinate.Y, GameEngine.ColorToValue(Color));
            }
            throw new Exception("Board is full!");
        }

    }
}
