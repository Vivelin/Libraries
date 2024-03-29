using Vivelin.Luck;

namespace Vivelin.Core.Tests.LuckTests;

public class SchrödingerTests
{
    [Fact]
    public void SchrodingersString_ResolvesToRandomString()
    {
        var values = new[] { "Bulbasaur", "Charmander", "Squirtle" };
        var instance = new Schrödinger<string>(values);
        var random = Substitute.For<Random>();
        random.Next(2).Returns(0);

        instance.Resolve(random).Should().Be("Bulbasaur");
    }

    [Fact]
    public void SchrodingersString_ImplicitlyResolvesToRandomString()
    {
        var values = new List<string>(["Bulbasaur", "Charmander", "Squirtle"]);
        var instance = new Schrödinger<string>(values);

        // Avoiding FluentAssertions here to demonstrate implicit usage
        Assert.Contains(instance, values);
    }

    [Fact]
    public void SchrodingersWeightedString_SelectsHigherWeightsMoreOften()
    {
        var instance = new Schrödinger<Weighted<string>>([
            new("Bulbasaur", 100),
            new("Charmander", 1),
            new("Squirtle", 1),
        ]);

        var values = Enumerable.Range(0, 100).Select(_ => instance.Resolve());
        var bulbasaurs = values.Count(x => x.Value == "Bulbasaur");
        var charmanders = values.Count(x => x.Value == "Charmander");
        var squirtles = values.Count(x => x.Value == "Squirtle");
        bulbasaurs.Should().NotBeCloseTo(charmanders, delta: 70);
        bulbasaurs.Should().NotBeCloseTo(squirtles, delta: 70);
    }
}
