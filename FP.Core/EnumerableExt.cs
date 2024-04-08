using System.Collections.Immutable;
using FP.Core.Option;

namespace FP.Core;

using static FP.Core.Prelude.Prelude;
using Unit = System.ValueTuple;
public static class EnumerableExt
{
    public static Option<T> Lookup<T>(this IEnumerable<T> ts,
        Func<T, bool> predicate)
    {
        foreach (var t in ts) if (predicate(t)) return Some(t);
        return None;
    }

    public static IEnumerable<Unit> ForEach<T>
        (this IEnumerable<T> ts, Action<T> action)
        => ts.Select(action.ToFunc()).ToImmutableList();
}