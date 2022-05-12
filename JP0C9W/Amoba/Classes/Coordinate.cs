using Amoba.Interfaces;

namespace Amoba.Classes
{
    public class Coordinate : ICoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordinate(int x) : this(x, 0) { }
        public Coordinate() : this(0, 0) { }

        public RecordCoordinate ToImmutable()
        {
            return new RecordCoordinate(X, Y);
        }
        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }
}
