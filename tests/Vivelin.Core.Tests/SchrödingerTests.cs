namespace Vivelin.Core.Tests;

public class SchrödingerTests
{
    [Fact]
    public void SchrodingersString_ImplicitlyResolvesToRandomString()
    {
        var values = new[] { "Bulbasaur", "Charmander", "Squirtle" };
        var instance = new Schrödinger<string>(values);
        
        // Avoiding FluentAssertions here to demonstrate implicit usage
        Assert.Contains(instance, values);
    }
}