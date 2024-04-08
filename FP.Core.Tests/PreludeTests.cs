using Xunit;

using static FP.Core.Prelude.Prelude;

namespace FP.Core.Tests;

public class Prelude_List_Tests
{
    [Fact]
    public void List_ShouldCreateImmutableEnumerable()
    {
        var threeElementList = List("Karina", "Andrej", "Natasha");
        Assert.Equal(3, threeElementList.Count());
    }
}