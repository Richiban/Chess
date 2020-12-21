namespace Serialization
{
    public interface IChessSerializer<T>
    {
        string Serialize(T item);
    }
}