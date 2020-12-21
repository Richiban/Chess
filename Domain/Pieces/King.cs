using System.Collections.Generic;

namespace Richiban.Chess.Domain
{
    public sealed class King : Piece
    {
        public override string Name => nameof(King);

        public override Colour Colour => throw new System.NotImplementedException();

        public override IEnumerable<Position> GetLegalMoves(Board board, Position currentPosition)
        {
            throw new System.NotImplementedException();
        }
    }
}
