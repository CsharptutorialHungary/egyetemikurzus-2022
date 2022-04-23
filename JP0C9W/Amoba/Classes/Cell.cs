using Amoba.Interfaces;

namespace Amoba.Classes
{
    public class Cell : ICell
    {
        private int _x;
        private int _y;
        public int X
        {
            get { return _x; }
            set { _x = value < 0 ? 0 : value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value < 0 ? 0 : value; }
        }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Cell(int x) : this(x, 0) { }
        public Cell() : this(0, 0) { }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }
}
