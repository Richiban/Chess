using Richiban.Chess.Domain;

namespace Richiban.Chess.Serialization
{
    public class PieceSerializer : IChessSerializer<Piece>
    {
        public string Serialize(Piece piece)
        {
            return piece switch
            {
                Queen => "Q",
                King => "K",
                Rook => "R",
                Knight => "N",
                Bishop => "B",
                _ => ""
            };
        }
    }
}
