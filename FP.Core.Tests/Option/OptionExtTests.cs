using FP.Core.Option;
using Xunit;

namespace FP.Core.Tests.Option;
using static Prelude;
public class Option_Map_Tests
{
    record Apple();

    record ApplePie(Apple Apple);

    private Func<Apple, ApplePie> _makePie = apple => new ApplePie(apple);

    [Fact]
    public void GivenSomeApple_WhenMakePie_ThenSomePie()
    {
        var apple = Some(new Apple());
        var pie = apple.Map(_makePie);
        Assert.True(pie.IsSome());
    }
    
    [Fact]
    public void GivenNoApple_WhenMakePie_ThenNoPie()
    {
        Option<Apple> apple = None;
        var pie = apple.Map(_makePie);
        Assert.False(pie.IsSome());
    }
}

public class Option_ForEach_Tests
{
    record Person(string Name);
    
    [Fact]
    public void ForEach_ShouldCorrectlyPerformsSideEffects()
    {
        var globalState = string.Empty;
        var person = Some(new Person("Francesco"));
        var sideEffectFunc =
            (string newState, ref string mutableState) => { mutableState = newState; };
        
        person
            .Map(p => $"Hello, {p.Name}")
            .ForEach(p => sideEffectFunc(p, ref globalState));
        
        Assert.Equal("Hello, Francesco", globalState);
    }
}
