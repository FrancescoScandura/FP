using System.Text.Json;
using FP.Core.Option;
using Xunit;

using static FP.Core.Option.Prelude;

namespace FP.Core.Tests.Option;

public class OptionJsonTests
{
    record Person(string FirstName, Option<string> MiddleName, string Lastname);

    private readonly JsonSerializerOptions _ops = new()
    {
        Converters = { new OptionJson.OptionConverter() }
    };

    [Fact]
    public void WhenJsonIsNull_ThenCSharpIsNone()
    {
        var json = @"{""FirstName"":""Virginia"",
            ""MiddleName"":null, ""LastName"":""Woolf""}";

        var deserialized = JsonSerializer.Deserialize<Person>(json, _ops);
        
        Assert.Equal(None, deserialized.MiddleName);
    }
    
    [Fact]
    public void WhenJsonIsNotNull_ThenCSharpIsSome()
    {
        var json = @"{""FirstName"":""Edgar"",
            ""MiddleName"":""Allan"", ""LastName"":""Poe""}";

        var deserialized = JsonSerializer.Deserialize<Person>(json, _ops);
        
        Assert.Equal(Some("Allan"), deserialized.MiddleName);
    }
}