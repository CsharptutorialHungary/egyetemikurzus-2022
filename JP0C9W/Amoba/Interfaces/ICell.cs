namespace Amoba.Interfaces
{
    public interface ICell<T>
    {
        ICoordinate Coordinate { get; }
        T Value { get; }
    }
}
