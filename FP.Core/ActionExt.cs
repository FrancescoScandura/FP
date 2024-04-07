using Unit = System.ValueTuple;

namespace FP.Core;

public static class ActionExt
{
    public static Func<Unit> ToFunc(this Action action)
        => () => { action(); return default; };
    
    public static Func<T, Unit> ToFunc<T>(this Action<T> action)
        => (t) => { action(t); return default; };
}