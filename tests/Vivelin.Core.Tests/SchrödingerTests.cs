namespace Vivelin.Core.Tests;

public class Schr�dingerTests
{
    [Fact]
    public void SchrodingersString_ImplicitlyResolvesToRandomString()
    {
        var values = new[] { "Bulbasaur", "Charmander", "Squirtle" };
        var instance = new Schr�dinger<string>(values);
        
        // Avoiding FluentAssertions here to demonstrate implicit usage
        Assert.Contains(instance, values);
    }
}