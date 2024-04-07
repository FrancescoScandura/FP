using FP.Core.Option;
using FsCheck.Xunit;
using Xunit;

namespace FP.Core.Tests.Option;

using static Prelude;

public class Tests
{
    [Fact]
    public void MatchCallsAppropriateFunc()
    {
        Assert.Equal("Hello, John", Greet(Some("John")));
        Assert.Equal("Sorry, who?", Greet(None));
    }

    [Fact]
    public void Apply_CalledOnNone_WithSome_ShouldReturnNone()
        =>
            Assert.Equal(None,
                NoneToApply.Apply(Some(1)));
    
    [Fact]
    public void Apply_CalledOnSome_WithNone_ShouldReturnNone()
        =>
            Assert.Equal(None,
                Some(Add10).Apply(None));
    
    private static string Greet(Option<string> greetee)
        => greetee.Match(
            None: () => "Sorry, who?",
            Some: (name) => $"Hello, {name}");

    private static readonly Option<Func<int, int>> NoneToApply = None;
    private static readonly Func<int, int> Add10 = x => x + 10;
}