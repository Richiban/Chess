using System.Collections.Generic;

namespace Richiban.Chess.Domain
{
    public abstract class Piece
    {
        public abstract string Name { get; }
        public abstract Colour Colour { get; }

        public bool CanTake(Piece other) => other.Colour != this.Colour;

        public abstract IEnumerable<Move> GetLegalMoves(BoardState board, Position currentPosition, bool isFirstMove);

        public override string ToString() => Name;
    }
}
