namespace FP.Core.Option;

using Unit = System.ValueTuple;
using static Prelude;

public static class OptionExt
{
    public static bool IsSome<T>(this Option<T> @this)
        => @this.Match(
            () => false,
            (_) => true);
    public static Option<R> Map<T, R>(this Option<T> @this,
        Func<T, R> f)
        => @this.Match(
            () => None,
            (t) => Some(f(t)));
    
    public static Option<R> Apply<T, R>
        (this Option<Func<T, R>> @this, Option<T> arg)
        => @this.Match(
            () => None,
            (func) => arg.Match(
                () => None,
                (val) => Some(func(val))));
    
    public static Unit Match<T>(this Option<T> option,
        Action None, Action<T> Some)
        => option.Match(None.ToFunc(), Some.ToFunc());

    public static Option<Unit> ForEach<T>(this Option<T> opt,
        Action<T> action)
        => Map(opt, action.ToFunc());

    public static Option<R> Bind<T, R>(Option<T> opt, Func<T, Option<R>> f)
        => opt.Match(
            () => None,
            (t) => f(t));
}