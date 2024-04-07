using FP.Core.Option;
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
    
    private static string Greet(Option<string> greetee)
        => greetee.Match(
            None: () => "Sorry, who?",
            Some: (name) => $"Hello, {name}");
}