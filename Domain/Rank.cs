using System;
using System.Linq;
using Richiban.Chess.Bcl;

namespace Richiban.Chess.Domain
{
    public sealed class Rank
    {
        private Rank(string name) { Name = name; }

        public string Name { get; }

        public static Rank _1 { get; } = new Rank("1");
        public static Rank _2 { get; } = new Rank("2");
        public static Rank _3 { get; } = new Rank("3");
        public static Rank _4 { get; } = new Rank("4");
        public static Rank _5 { get; } = new Rank("5");
        public static Rank _6 { get; } = new Rank("6");
        public static Rank _7 { get; } = new Rank("7");
        public static Rank _8 { get; } = new Rank("8");

        public override string ToString() => Name;

        public static Option<Rank> operator +(Rank rank, int squares)
        {
            Option<Rank> Reduce(Func<Rank, Option<Rank>> f)
            {
                var state = (Option<Rank>)rank;

                foreach (var i in System.Linq.Enumerable.Range(0, Math.Abs(squares)))
                {
                    state = state.Bind(f);
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
            this == _1 ? _2
            : this == _2 ? _3
            : this == _3 ? _4
            : this == _4 ? _5
            : this == _5 ? _6
            : this == _6 ? _7
            : this == _7 ? _8
            : null;

        private Option<Rank> Down =>
            this == _2 ? _1
            : this == _3 ? _2
            : this == _4 ? _3
            : this == _5 ? _4
            : this == _6 ? _5
            : this == _7 ? _6
            : this == _8 ? _7
            : null;
    }
}
