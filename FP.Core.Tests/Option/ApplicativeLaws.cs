using FP.Core.Option;
using FsCheck.Xunit;
using Xunit;

namespace FP.Core.Tests.Option;

using static Prelude;

public static class ApplicativeLaws
{
    private static Func<int, int> minus10 = (a) => a - 10;

    [Property]
    public static void HomomorphismHolds(int x)
        => Assert.Equal(
            Some(minus10).Apply(Some(x)),
            Some(minus10(x)));
}