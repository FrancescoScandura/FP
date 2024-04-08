using System.Collections.Immutable;

namespace FP.Core.Prelude;

public static partial class Prelude
{
    public static IEnumerable<T> List<T>(params T[] items)
        => items.ToImmutableList();
}