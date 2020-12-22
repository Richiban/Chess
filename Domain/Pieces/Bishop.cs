using System;
using System.Collections.Generic;
using System.Linq;
using Richiban.Chess.Bcl;

namespace Richiban.Chess.Domain
{
    public sealed class Bishop : Piece
    {
        public Bishop(Colour colour)
        {
            Colour = colour;
        }

        public override string Name => nameof(Bishop);

        public override Colour Colour { get; }

        public override IEnumerable<Move> GetLegalMoves(Board board, Position currentPosition, bool _ = default)
        {
            var moves =
                GetMoveSquares(board, currentPosition)
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

        private IEnumerable<Position> GetMoveSquares(Board board, Position currentPosition)
        {
            var directions =
                Bcl.Enumerable.Unreduce(new ChessVector(1, 1), v => v.RotateRight(ChessVector.RotateAngle.OneInFour))
                .Take(4);

            foreach (var direction in directions)
            {
                var current = currentPosition;

                do
                {
                    if (!(current + direction).IsSome(out var newPosition)) break;

                    if (board.IsEmpty(newPosition))
                    {
                        yield return newPosition;

                        current = newPosition;
                    }
                    else
                    {
                        if (board.GetOccupant(newPosition).IsSome(out var piece) && CanTake(piece))
                        {
                            yield return newPosition;
                            break;
                        }
                        break;
                    }
                } while (true);
            }
        }
    }
}
