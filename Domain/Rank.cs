using System;
using System.Linq;

namespace Richiban.Chess.Domain
{
    public sealed class Rank
    {
        private Rank() { }

        public static Rank Rank1 { get; } = new Rank();
        public static Rank Rank2 { get; } = new Rank();
        public static Rank Rank3 { get; } = new Rank();
        public static Rank Rank4 { get; } = new Rank();
        public static Rank Rank5 { get; } = new Rank();
        public static Rank Rank6 { get; } = new Rank();
        public static Rank Rank7 { get; } = new Rank();
        public static Rank Rank8 { get; } = new Rank();

        public static Option<Rank> operator +(Rank rank, int squares)
        {
            Option<Rank> Reduce(Func<Rank, Option<Rank>> f)
            {
                var state = (Option<Rank>)rank;

                foreach (var i in Enumerable.Range(0, Math.Abs(squares)))
                {
                    state = state.Bind(state => state.Up);
                }

                return state;
            }

            return squares switch
            {
                0 => rank,
                < 0 => Reduce(r => r.Down),
                > 0 => Reduce(r => r.Up)
            };
        }

        public static Option<Rank> operator -(Rank rank, int squares) => rank + (-squares);

        private Option<Rank> Up =>
            this == Rank1 ? Rank2
            : this == Rank2 ? Rank3
            : this == Rank3 ? Rank4
            : this == Rank4 ? Rank5
            : this == Rank5 ? Rank6
            : this == Rank6 ? Rank7
            : this == Rank7 ? Rank8
            : null;

        private Option<Rank> Down =>
            this == Rank2 ? Rank1
            : this == Rank3 ? Rank2
            : this == Rank4 ? Rank3
            : this == Rank5 ? Rank4
            : this == Rank6 ? Rank5
            : this == Rank7 ? Rank6
            : this == Rank8 ? Rank7
            : null;
    }
}
