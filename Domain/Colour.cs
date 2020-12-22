using System;
using Richiban.Chess.Bcl;

namespace Richiban.Chess.Domain
{
    public abstract class Colour
    {
        private Colour() { }

        public static Colour White { get; } = new WhiteColour();
        public static Colour Black { get; } = new BlackColour();

        public abstract Option<Position> Advance(Position currentPosition, ChessVector vector);

        private class WhiteColour : Colour
        {
            public override Option<Position> Advance(Position currentPosition, ChessVector vector) =>
                currentPosition + vector;
        }

        private class BlackColour : Colour
        {
            public override Option<Position> Advance(Position currentPosition, ChessVector vector) =>
                currentPosition - vector;
        }
    }
}
