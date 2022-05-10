using Amoba.Interfaces;

namespace Amoba.Classes
{
    internal class RandomPlayer : IPlayer
    {
        private ICollection<IBoardCell> FreeCells;
        public PlayerColor Color { get; set; }
        public PlayerType Type { get; }
        public static void ShuffleCollection<T>(ref ICollection<T> col)
        {
            col = col.OrderBy(i => GameEngine.RANDOM.Next()).ToList();
        } 
        public RandomPlayer(PlayerColor color, IBoard<char> board)
        {
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

        public IBoardCell GetMove(IBoard<char> board, IBoardCell? prevMove)
        {
            if (FreeCells.Count > 0)
                {
                if (prevMove != null)
                {
                    IBoardCell? prevCell = null;
                    try
                    {
                        prevCell = FreeCells.Single(cell => cell.Y == prevMove.Y && cell.X == prevMove.X);
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
                var selectedCell = FreeCells.ElementAt(GameEngine.RANDOM.Next(0, FreeCells.Count));
                FreeCells.Remove(selectedCell);
                return new BoardCell(selectedCell.X, selectedCell.Y, GameEngine.ColorToValue(Color));
            }
            throw new Exception("Board is full!");
        }

    }
}
