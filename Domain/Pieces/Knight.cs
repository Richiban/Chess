using System.Collections.Generic;

namespace Richiban.Chess.Domain
{
    public sealed class Knight : Piece
    {
        public override string Name => nameof(Knight);

        public override Colour Colour => throw new System.NotImplementedException();

        public override IEnumerable<Position> GetLegalMoves(Board board, Position currentPosition)
        {
            throw new System.NotImplementedException();
        }
    }
}
