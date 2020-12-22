using System.Collections.Generic;

namespace Richiban.Chess.Domain
{
    public sealed class Pawn : Piece
    {
        public Pawn(Colour colour)
        {
            Colour = colour;
        }

        public override string Name => nameof(Pawn);

        public override Colour Colour { get; }

        public override IEnumerable<Move> GetLegalMoves(Board boardState, Position currentPosition, bool isFirstMove = false)
        {
            var moveSquare = Colour.Advance(currentPosition, 1, 0);
            var moveSquare2 = Colour.Advance(currentPosition, 2, 0);
            var attackSquareLeft = Colour.Advance(currentPosition, 1, -1);
            var attackSquareRight = Colour.Advance(currentPosition, 1, +1);

            if (attackSquareLeft.Bind(boardState.GetOccupant).Map(CanTake) | false)
            {
                yield return new Move(this, currentPosition, attackSquareLeft.Force()) { IsTake = true };
            }

            if (attackSquareRight.Bind(boardState.GetOccupant).Map(CanTake) | false)
            {
                yield return new Move(this, currentPosition, attackSquareRight.Force()) { IsTake = true };
            }

            if (moveSquare.Map(boardState.IsEmpty) | false)
            {
                yield return new Move(this, currentPosition, moveSquare.Force());
            }

            if (isFirstMove && (moveSquare.Map(boardState.IsEmpty) | false) && (moveSquare2.Map(boardState.IsEmpty) | false))
            {
                yield return new Move(this, currentPosition, moveSquare2.Force());
            }
        }
    }
}
