using System;

namespace Richiban.Chess.Domain
{
    public sealed record ChessVector(int X, int Y)
    {
        public ChessVector RotateRight(RotateAngle angle)
        {
            switch (angle)
            {
                case RotateAngle.OneInFour:
                    return new ChessVector(Y, -X);
                case RotateAngle.OneInEight:
                    if (X == Y) return this with { Y = 0 };
                    if (Y == 0) return this with { Y = -X };
                    if (Y == -X) return this with { X = 0 };
                    if (X == 0) return this with { X = Y };

                    throw new ArgumentException($"The vector {this} cannot be rotated by {angle} on a Chess board");
                default: throw new InvalidOperationException($"Unrecognised {nameof(RotateAngle)}: {angle}");
            }

            throw new NotImplementedException("Vector.Rotate");
        }

        private bool IsStraight => X == 0 || Y == 0;
        private bool IsDiagonal => X == Y || X == -Y;

        public enum RotateAngle
        {
            OneInEight, OneInFour
        }
    }
}
