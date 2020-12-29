using Richiban.Chess.Domain;

namespace Richiban.Chess.Serialization
{
    public class BoardSerializer : IChessSerializer<BoardState>
    {
        public string Serialize(BoardState item)
        {
            return "";
        }
    }
}
