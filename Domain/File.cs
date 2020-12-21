using System;
using System.Linq;

namespace Richiban.Chess.Domain
{
    public sealed class File
    {
        private File() { }

        public static File A { get; } = new File();
        public static File B { get; } = new File();
        public static File C { get; } = new File();
        public static File D { get; } = new File();
        public static File E { get; } = new File();
        public static File F { get; } = new File();
        public static File G { get; } = new File();
        public static File H { get; } = new File();

        public static Option<File> operator +(File File, int squares)
        {
            Option<File> Reduce(Func<File, Option<File>> f)
            {
                var state = (Option<File>)File;

                foreach (var i in Enumerable.Range(0, Math.Abs(squares)))
                {
                    state = state.Bind(state => state.Right);
                }

                return state;
            }

            return squares switch
            {
                0 => File,
                < 0 => Reduce(r => r.Left),
                > 0 => Reduce(r => r.Right)
            };
        }

        public static Option<File> operator -(File File, int squares) => File + (-squares);

        private Option<File> Right =>
            this == A ? B
            : this == B ? C
            : this == C ? D
            : this == D ? E
            : this == E ? F
            : this == F ? G
            : this == G ? H
            : null;

        private Option<File> Left =>
            this == B ? A
            : this == C ? B
            : this == D ? C
            : this == E ? D
            : this == F ? E
            : this == G ? F
            : this == H ? G
            : null;
    }
}
