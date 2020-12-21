using System;

namespace Domain
{
    public abstract class Colour
    {
        private Colour() { }

        public static Colour White { get; } = new WhiteColour();
        public static Colour Black { get; } = new BlackColour();

        public abstract Option<Position> Advance(Position currentPosition, int forwards, int right);

        private class WhiteColour : Colour
        {
            public override Option<Position> Advance(Position currentPosition, int forwards, int right)
            {
                var maybeNewRank = currentPosition.Rank + forwards;
                var maybeNewFile = currentPosition.File + right;

                return from newRank in maybeNewRank
                       from newFile in maybeNewFile
                       select currentPosition with { Rank = newRank, File = newFile };
            }
        }

        private class BlackColour : Colour
        {
            public override Option<Position> Advance(Position currentPosition, int forwards, int right)
            {
                var maybeNewRank = currentPosition.Rank - forwards;
                var maybeNewFile = currentPosition.File - right;

                return from newRank in maybeNewRank
                       from newFile in maybeNewFile
                       select currentPosition with { Rank = newRank, File = newFile };
            }
        }
    }
}
