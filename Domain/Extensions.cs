using System;
using System.Collections.Generic;

namespace Richiban.Chess.Domain
{
    public static class Extensions
    {
        public static Option<T> FirstOrNone<T>(this IEnumerable<T> source, Func<T, bool> f)
        {
            foreach (var item in source)
            {
                if (f(item))
                {
                    return item;
                }
            }

            return new();
        }
    }
}
