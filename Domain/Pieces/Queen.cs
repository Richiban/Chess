using System.Collections.Generic;

namespace Richiban.Chess.Domain
{
    public sealed class Queen : Piece
    {
        public override string Name => nameof(Queen);

        public override Colour Colour => throw new System.NotImplementedException();

        public override IEnumerable<Position> GetLegalMoves(Board board, Position currentPosition)
        {
            throw new System.NotImplementedException();
        }
    }
}
