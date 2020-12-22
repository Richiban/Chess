using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Richiban.Chess.Domain
{
    public sealed record ChessVector(int Files, int Ranks)
    {
        public IReadOnlyCollection<ChessVector> GetRotations(RotateAngle angle)
        {
            var count = angle switch
            {
                RotateAngle.OneInFour => 4,
                RotateAngle.OneInEight => 8,
                _ => throw new InvalidOperationException($"Unrecognised {nameof(RotateAngle)}: {angle}")
            };

            return Bcl.Enumerable.Unfold(this, v => v.RotateRight(angle))
                .Take(count)
                .ToImmutableList();
        }

        private ChessVector RotateRight(RotateAngle angle)
        {
            switch (angle)
            {
                case RotateAngle.OneInFour:
                    return new ChessVector(Ranks, -Files);
                case RotateAngle.OneInEight:
                    if (Files == Ranks) return this with { Ranks = 0 };
                    if (Ranks == 0) return this with { Ranks = -Files };
                    if (Ranks == -Files) return this with { Files = 0 };
                    if (Files == 0) return this with { Files = Ranks };

                    throw new ArgumentException($"The vector {this} cannot be rotated by {angle} on a Chess board");
                default: throw new InvalidOperationException($"Unrecognised {nameof(RotateAngle)}: {angle}");
            }

            throw new NotImplementedException("Vector.Rotate");
        }

        public enum RotateAngle
        {
            OneInEight, OneInFour
        }
    }
}
