using System;
using System.Collections.Generic;
using System.Linq;
using Richiban.Chess.Bcl;

namespace Richiban.Chess.Domain
{
    public sealed class Knight : Piece
    {
        public Knight(Colour colour)
        {
            Colour = colour;
        }

        public override string Name => nameof(Knight);
        public override Colour Colour { get; }

        public override IEnumerable<Move> GetLegalMoves(Board board, Position currentPosition, bool _ = default)
        {
            var moves =
                GetMoveSquares(currentPosition)
                .SelectWhere(pos =>
                {
                    if (board.IsEmpty(pos))
                        return new Move(this, currentPosition, pos);

                    if (board.GetOccupant(pos).IsSome(out var piece) && CanTake(piece))
                    {
                        return new Move(this, currentPosition, pos) { IsTake = true };
                    }

                    return new Option<Move>();
                });

            return moves;
        }

        private IEnumerable<Position> GetMoveSquares(Position currentPosition)
        {
            var vectors = Bcl.Enumerable.Unreduce(
                (left: new ChessVector(2, -1), right: new ChessVector(2, +1)),
                prev =>
                    (prev.left.RotateRight(ChessVector.RotateAngle.OneInFour),
                     prev.right.RotateRight(ChessVector.RotateAngle.OneInFour)))
                .Take(4)
                .Unzip();

            return vectors.Select(v => currentPosition + v).Somes();
        }
    }
}
