using System.Diagnostics.CodeAnalysis;
using FP.Core.Option;

namespace FP.Core.Prelude
{
    public static partial class Prelude
    {
        public static NoneType None => default;

        public static Option<T> Some<T>([NotNull] T? value)
            => value ?? throw new ArgumentNullException(nameof(value));
    }
}

namespace FP.Core.Option
{
    using static FP.Core.Prelude.Prelude;
    public struct NoneType
    {
    }
    
    public readonly struct Option<T>
    {
        private readonly T? _value;
        private readonly bool _isSome;

        private Option(T t) => (_isSome, _value) = (true, t);

        public static implicit operator Option<T>(NoneType _)
            => default;

        public static implicit operator Option<T>(T t)
            => t is null ? None : new Option<T>(t);

        public R Match<R>(Func<R> None, Func<T, R> Some)
            => _isSome ? Some(_value!) : None();

        public IEnumerable<T> AsEnumerable()
        {
            if (_isSome) yield return _value!;
        }
    }
}