using FP.Core.Option;

namespace FP.Core;

using static FP.Core.Prelude.Prelude;

public static class Int
{
    public static Option<int> Parse(string s)
        => int.TryParse(s, out int result)
            ? Some(result)
            : None;
}