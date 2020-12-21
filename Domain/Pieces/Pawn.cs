using System.Collections.Generic;

namespace Domain
{
    public sealed class Pawn : Piece
    {
        public Pawn(Colour colour)
        {
            Colour = colour;
        }

        public override string Name => nameof(Pawn);

        public override Colour Colour { get; }

        public override IEnumerable<Position> GetLegalMoves(Board boardState, Position currentPosition)
        {
            var moveSquare = Colour.Advance(currentPosition, 1, 0);
            var attackSquareLeft = Colour.Advance(currentPosition, 1, -1);
            var attackSquareRight = Colour.Advance(currentPosition, 1, +1);

            if (attackSquareLeft.Bind(boardState.GetOccupant).Map(CanTake) | false)
            {
                yield return attackSquareLeft.Force();
            }

            if (attackSquareRight.Bind(boardState.GetOccupant).Map(CanTake) | false)
            {
                yield return attackSquareRight.Force();
            }

            if (moveSquare.Map(boardState.IsEmpty) | false)
            {
                yield return moveSquare.Force();
            }
        }
    }
}
