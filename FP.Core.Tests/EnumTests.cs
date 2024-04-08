using Xunit;

namespace FP.Core.Tests;

using static FP.Core.Prelude.Prelude;

public class EnumTests
{
    [Fact]
    public void Parse_IfValidEnumString_ShouldReturnsSome()
    {
        var friday = Enum.Parse<DayOfWeek>("Friday");
        Assert.Equal(Some(DayOfWeek.Friday), friday);
    }
    
    [Fact]
    public void Parse_IfInvalidEnumString_ShouldReturnsNone()
    {
        var freeday = Enum.Parse<DayOfWeek>("Freeday");
        Assert.Equal(None, freeday);
    }
}