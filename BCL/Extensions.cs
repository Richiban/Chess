using System;
using System.Collections.Generic;
using Richiban.Chess.Bcl;

namespace System.Linq
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

        public static IEnumerable<T> Somes<T>(this IEnumerable<Option<T>> source)
        {
            foreach (var item in source)
            {
                if (item.HasValue)
                {
                    yield return item.Force();
                }
            }
        }

        public static IEnumerable<R> SelectWhere<T, R>(this IEnumerable<T> source, Func<T, Option<R>> f)
        {
            foreach (var item in source)
            {
                var result = f(item);

                if (result.HasValue)
                {
                    yield return result.Force();
                }
            }
        }

        public static IEnumerable<T> Unzip<T>(this IEnumerable<(T, T)> source)
        {
            foreach (var item in source)
            {
                yield return item.Item1;
                yield return item.Item2;
            }
        }
    }
}
