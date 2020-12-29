using System;
using System.Collections.Generic;
using Richiban.Chess.Bcl;

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

        public override IEnumerable<Move> GetLegalMoves(BoardState boardState, Position currentPosition, bool isFirstMove = false)
        {
            var moveSquare = Colour.Advance(currentPosition, new ChessVector(0, 1));
            var moveSquare2 = Colour.Advance(currentPosition, new ChessVector(0, 2));
            var attackSquareLeft = Colour.Advance(currentPosition, new ChessVector(-1, +1));
            var attackSquareRight = Colour.Advance(currentPosition, new ChessVector(+1, +1));

            Func<Position, Option<Piece>> getOccupant = (pos) => boardState[pos];

            if (attackSquareLeft.Bind(getOccupant).Map(CanTake) | false)
            {
                yield return new Move(this, currentPosition, attackSquareLeft.Force()) { IsTake = true };
            }

            if (attackSquareRight.Bind(getOccupant).Map(CanTake) | false)
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
