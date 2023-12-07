using Vivelin.Luck;

namespace Vivelin.Core.Tests.LuckTests;

public class EnumerableExtensionsTests
{
    [Fact]
    public void Sample_ReturnsRandomValue()
    {
        var values = new List<string>(["Bulbasaur", "Charmander", "Squirtle"]);

        values.Sample(Random.Shared).Should().BeOneOf(values);
    }

    [Fact]
    public void Sample_ReturnsWeightedRandomValue()
    {
        var values = new List<Weighted<string>>([
            new("Bulbasaur", 100),
            new("Charmander", 1),
            new("Squirtle", 1),
        ]);

        var results = Enumerable.Range(0, 100).Select(_ => values.WeightedSample(Random.Shared));
        var bulbasaurs = results.Count(x => x.Value == "Bulbasaur");
        var charmanders = results.Count(x => x.Value == "Charmander");
        var squirtles = results.Count(x => x.Value == "Squirtle");
        bulbasaurs.Should().NotBeCloseTo(charmanders, delta: 70);
        bulbasaurs.Should().NotBeCloseTo(squirtles, delta: 70);
    }
}
