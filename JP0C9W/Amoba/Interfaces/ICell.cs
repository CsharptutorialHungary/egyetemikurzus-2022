namespace Amoba.Interfaces
{
    public interface ICell<T> : ICoordinate
    {
        T Value { get; }
    }
}
