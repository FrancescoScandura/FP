namespace FP.Core.Option;

using static Prelude;

public static class OptionExt
{
    public static Option<R> Apply<T, R>
        (this Option<Func<T, R>> @this, Option<T> arg)
        => @this.Match(
            () => None,
            (func) => arg.Match(
                () => None,
                (val) => Some(func(val))));
}