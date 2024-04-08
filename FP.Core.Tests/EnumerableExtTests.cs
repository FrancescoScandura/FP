using FP.Core.Option;
using Xunit;

namespace FP.Core.Tests;

using static Prelude;

public class Enumerable_Lookup_Tests
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

public class Enumerable_ForEach_Tests
{
    [Fact]
    public void ForEach_ShouldCorrectlyPerformsSideEffects()
    {
        var counter = 1;
        Enumerable.Range(1, 10).ForEach(i => counter += i);
        Assert.Equal(56, counter);
    }
}