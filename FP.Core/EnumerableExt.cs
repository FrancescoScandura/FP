using FP.Core.Option;

namespace FP.Core;

using static Prelude;

public static class EnumerableExt
{
    public static Option<T> Lookup<T>(this IEnumerable<T> @this,
        Func<T, bool> predicate)
    {
        foreach (var t in @this) if (predicate(t)) return Some(t);
        return None;
    }
}