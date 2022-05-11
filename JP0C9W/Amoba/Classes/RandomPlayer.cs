using Amoba.Interfaces;

namespace Amoba.Classes
{
    public record class RandomPlayer : IPlayer
    {
        private IList<IBoardCell> FreeCells;
        public PlayerColor Color { get; init; }
        public PlayerType Type { get; init; }
        public static void ShuffleCollection<T>(ref IList<T> col)
        {
            col = col.OrderBy(i => GameEngine.RANDOM.Next()).ToList();
        } 
        public RandomPlayer(PlayerColor color, IBoard<char> board)
        {
            Type = PlayerType.AI;
            Color = color;
            FreeCells = new List<IBoardCell>();
            var cells = board.Cells;
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    if (cells.ElementAt(i)[j] == Board.EMPTY_CELL)
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
                        FreeCells.Remove(prevCell);
                    } 
                    catch (Exception)
                    {
                        throw;
                    }
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
