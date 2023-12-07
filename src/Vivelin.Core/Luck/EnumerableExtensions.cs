using System.Diagnostics;

namespace Vivelin.Luck;

public static class EnumerableExtensions
{
    public static T Sample<T>(this IReadOnlyList<T> source)
        => source.Sample(Random.Shared);

    public static T Sample<T>(this IReadOnlyList<T> source, Random rng)
    {
        var index = rng.Next(source.Count);
        return source[index];
    }

    public static T WeightedSample<T>(this IEnumerable<T> source) where T : IWeighted
        => source.WeightedSample(Random.Shared);

    public static T WeightedSample<T>(this IEnumerable<T> source, Random rng) where T : IWeighted
    {
        var totalWeight = source.Sum(x => x.Weight);
        var targetWeight = rng.NextDouble() * totalWeight;

        foreach (var item in source)
        {
            if (targetWeight < item.Weight)
                return item;

            targetWeight -= item.Weight;
        }

        throw new UnreachableException();
    }
}
