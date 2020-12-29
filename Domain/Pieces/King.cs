using System.Collections.Generic;
using System.Linq;
using Richiban.Chess.Bcl;

namespace Richiban.Chess.Domain
{
    public sealed class King : Piece
    {
        public King(Colour colour)
        {
            Colour = colour;
        }

        public override string Name => nameof(King);

        public override Colour Colour { get; }

        public override IEnumerable<Move> GetLegalMoves(BoardState board, Position currentPosition, bool isFirstMove)
        {
            var moves =
                GetMoveSquares(currentPosition)
                .SelectWhere(pos =>
                {
                    if (board.IsEmpty(pos))
                        return new Move(this, currentPosition, pos);

                    if (board[pos].IsSome(out var piece) && CanTake(piece))
                    {
                        return new Move(this, currentPosition, pos) { IsTake = true };
                    }

                    return new Option<Move>();
                });

            return moves;
        }

        private IEnumerable<Position> GetMoveSquares(Position currentPosition) =>
            new ChessVector(+1, +1).GetRotations(ChessVector.RotateAngle.OneInEight)
                .Select(v => Colour.Advance(currentPosition, v))
                .Somes();
    }
}
