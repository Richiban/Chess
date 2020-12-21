namespace Richiban.Chess.Serialization
{
    public interface IChessSerializer<T>
    {
        string Serialize(T item);
    }
}