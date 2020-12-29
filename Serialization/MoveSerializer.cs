using Richiban.Chess.Domain;

namespace Richiban.Chess.Serialization
{
    public class MoveSerializer
    {
        private readonly PieceSerializer _pieceSerializer;

        public MoveSerializer(PieceSerializer pieceSerializer)
        {
            _pieceSerializer = pieceSerializer;
        }

        public string Serialize(Move move, BoardState boardState)
        {
            var piece = _pieceSerializer.Serialize(move.Piece);
            var origin = move.Origin;
            var take = move.IsTake ? "x" : "";
            var destination = move.Destination;

            return string.Concat(piece, origin, take, destination);
        }
    }
}
