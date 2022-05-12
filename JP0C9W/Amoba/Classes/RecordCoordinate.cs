using Amoba.Interfaces;
namespace Amoba.Classes
{
    public record class RecordCoordinate : ICoordinate
    {
        public int X { get; init; }
        public int Y { get; init; }

        public RecordCoordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public RecordCoordinate(int x) : this(x, 0) { }
        public RecordCoordinate() : this(0, 0) { }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }
}
