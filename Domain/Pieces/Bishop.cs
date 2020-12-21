using System.Collections.Generic;

namespace Domain
{
    public sealed class Bishop : Piece
    {
        public Bishop(Colour colour)
        {
            Colour = colour;
        }

        public override string Name => nameof(Bishop);

        public override Colour Colour { get; }

        public override IEnumerable<Position> GetLegalMoves(Board board, Position currentPosition)
        {
            throw new System.NotImplementedException();
        }
    }
}
