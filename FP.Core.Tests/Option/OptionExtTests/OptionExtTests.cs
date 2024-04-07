using FP.Core.Option;
using Xunit;

namespace FP.Core.Tests.Option.OptionExtTests;
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