using Xunit;
using static FP.Core.Prelude.Prelude;
namespace FP.Core.Tests;

public class IntTests
{
    [Fact]
    public void Parse_ShouldParseCorrectly()
    {
        Assert.Equal(None, Int.Parse("invalidInt"));
        Assert.Equal(Some(1), Int.Parse("1"));
    }
}