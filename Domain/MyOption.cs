using System;
using System.Collections.Generic;

namespace Richiban.Chess.Domain
{
    public struct Option<T>
    {
        private readonly T _value;

        public Option(T value)
        {
            HasValue = value != null;
            _value = value;
        }

        public bool HasValue { get; }

        public static Option<(T, T)> operator
            &(Option<T> left, Option<T> right)
        {
            if (left.HasValue && right.HasValue)
                return new Option<(T, T)>((left._value, right._value));

            return new Option<(T, T)>();
        }

        public static T operator |(Option<T> left, T right)
        {
            if (left.HasValue) return left._value;

            return right;
        }

        public Option<R> Map<R>(Func<T, R> f)
        {
            if (HasValue) return new(f(_value));

            return new();
        }

        internal T Force()
        {
            return this | (() => throw new InvalidOperationException("Force None"));
        }

        public Option<R> Select<R>(Func<T, R> f)
        {
            if (HasValue) return new(f(_value));

            return new();
        }

        public Option<R> Bind<R>(Func<T, Option<R>> f)
        {
            if (HasValue) return f(_value);

            return new();
        }

        public static T operator |(Option<T> left, Func<T> right)
        {
            if (left.HasValue) return left._value;

            return right();
        }

        public static Option<T> operator |(Option<T> left, Option<T> right)
        {
            if (left.HasValue) return left;

            return right;
        }

        public static bool operator true(Option<T> left)
        {
            return left.HasValue;
        }

        public static bool operator false(Option<T> left)
        {
            return !left.HasValue;
        }

        public static implicit operator Option<T>(T x) => new Option<T>(x);

        public override string ToString() => $"{_value}";

        public Option<R> SelectMany<R>(Option<T> source, Func<T, Option<R>> f)
        {
            if (HasValue) return f(_value);

            return new();
        }

        public Option<R> SelectMany<TCollection, R>(Option<T> source, Func<T, Option<TCollection>> f1, Func<T, TCollection, R> f)
        {
            if (HasValue)
            {
                var inner = f1(_value);

                if (inner.HasValue)
                {
                    return f(_value, inner._value);
                }
            }

            return new();
        }
    }
}
