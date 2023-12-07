namespace Vivelin.Core.Tests;

public class SchrödingerTests
{
    [Fact]
    public void SchrodingersString_ResolvesToRandomString()
    {
        var values = new[] { "Bulbasaur", "Charmander", "Squirtle" };
        var instance = new Schrödinger<string>(values);
        var mockRandom = new Mock<Random>();
        mockRandom.Setup(x => x.Next(3)).Returns(0);

        instance.Resolve(mockRandom.Object).Should().Be("Bulbasaur");
    }

    [Fact]
    public void SchrodingersString_ImplicitlyResolvesToRandomString()
    {
        var values = new[] { "Bulbasaur", "Charmander", "Squirtle" };
        var instance = new Schrödinger<string>(values);
        
        // Avoiding FluentAssertions here to demonstrate implicit usage
        Assert.Contains(instance, values);
    }
}