using FP.Core.Option;

namespace FP.Core;

using static Prelude;

public static class Enum
{
    public static Option<T> Parse<T>(this string s) where T : struct
        => System.Enum.TryParse(s, out T t) ? Some(t) : None;
}