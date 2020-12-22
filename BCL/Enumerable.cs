using System;
using System.Collections.Generic;

namespace Richiban.Chess.Bcl
{
    public static class Enumerable
    {
        public static IEnumerable<T> Unreduce<T>(T seed, Func<T, T> f)
        {
            var state = seed;

            while (true)
            {
                var current = f(state);
                yield return current;
                state = current;
            }
        }
    }
}
