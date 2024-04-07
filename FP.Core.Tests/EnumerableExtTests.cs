using FP.Core.Option;
using Xunit;

namespace FP.Core.Tests;

using static Prelude;

public class EnumerableExtTests
{
    private static bool IsOdd(int i) => i % 2 == 1;
    
    [Fact]
    public void Lookup_OnList_WherePredicateIsFalse_ShouldReturnsNone()
    {
        var none = new List<int>().Lookup(IsOdd);
        Assert.Equal(None, none);
    }
    
    [Fact]
    public void Lookup_OnList_WherePredicateIsTrue_ShouldReturnsSome()
    {
        var odd = new List<int>{ 1 }.Lookup(IsOdd);
        Assert.Equal(Some(1), odd);
    }
}