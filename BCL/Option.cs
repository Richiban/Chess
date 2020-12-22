using System;
using System.Diagnostics.CodeAnalysis;

namespace Richiban.Chess.Bcl
{
    public struct Option<T>
    {
        private readonly T _value;

        public Option(T? value)
        {
            HasValue = value != null;
            _value = value!;
        }

        public bool HasValue { get; }

        public static T operator |(Option<T> left, T right)
        {
            if (left.HasValue) return left._value;

            return right;
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

        public bool IsSome([NotNullWhen(true)] out T value)
        {
            if (HasValue)
            {
                value = _value!;
                return true;
            }

            value = default!;
            return false;
        }

        public Option<R> Map<R>(Func<T, R> f)
        {
            if (HasValue) return new(f(_value));

            return new();
        }

        public T Force()
        {
            if (HasValue) return _value;

            throw new InvalidOperationException("Force None");
        }

        public Option<R> Bind<R>(Func<T, Option<R>> f)
        {
            if (HasValue) return f(_value);

            return new();
        }

        public static bool operator true(Option<T> left) => left.HasValue;

        public static bool operator false(Option<T> left) => !left.HasValue;

        public static implicit operator Option<T>(T? x) => new Option<T>(x);

        public override string ToString() => $"{_value}";

        public Option<R> Select<R>(Func<T, R> f)
        {
            if (HasValue) return new(f(_value));

            return new();
        }

        public Option<R> SelectMany<R>(Func<T, Option<R>> func)
        {
            if (HasValue)
                return func(_value);

            return new Option<R>();
        }

        public Option<R> SelectMany<U, R>(
            Func<T, Option<U>> intermediateSelector,
            Func<T, U, R> resultSelector)
        {
            if (HasValue)
            {
                var inner = intermediateSelector(_value);

                if (inner.HasValue)
                {
                    return resultSelector(_value, inner._value);
                }
            }

            return new Option<R>();
        }

    }
}
