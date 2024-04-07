using System.Text.Json;
using FP.Core.Option;
using Xunit;

using static FP.Core.Option.Prelude;

namespace FP.Core.Tests.Option;

public class OptionJsonTests
{
    record Person(string FirstName, Option<string> MiddleName, string LastName);

    private readonly JsonSerializerOptions _ops = new()
    {
        Converters = { new OptionJson.OptionConverter() }
    };

    [Fact]
    public void Read_WhenJsonIsNull_ThenCSharpIsNone()
    {
        var json = @"{""FirstName"":""Virginia"",
            ""MiddleName"":null, ""LastName"":""Woolf""}";

        var deserialized = JsonSerializer.Deserialize<Person>(json, _ops);
        
        Assert.Equal(None, deserialized.MiddleName);
    }
    
    [Fact]
    public void Read_WhenJsonIsNotNull_ThenCSharpIsSome()
    {
        var json = @"{""FirstName"":""Edgar"",
            ""MiddleName"":""Allan"", ""LastName"":""Poe""}";

        var deserialized = JsonSerializer.Deserialize<Person>(json, _ops);
        
        Assert.Equal(Some("Allan"), deserialized.MiddleName);
    }
    
    [Fact]
    public void Write_WhenCSharpIsSome_ThenJsonIsNotNull()
    {
        const string expected = """{"FirstName":"Edgar","MiddleName":"Allan","LastName":"Poe"}""";
        
        var edgar = new Person("Edgar", "Allan", "Poe");

        var serialized = JsonSerializer.Serialize(edgar, _ops);
        
        Assert.Equal(expected, serialized);
    }
    
    [Fact]
    public void Write_WhenCSharpIsNone_ThenJsonIsNull()
    {
        const string expected = """{"FirstName":"Edgar","MiddleName":null,"LastName":"Poe"}""";
        
        var edgar = new Person("Edgar", None, "Poe");

        var serialized = JsonSerializer.Serialize(edgar, _ops);
        
        Assert.Equal(expected, serialized);
    }
}