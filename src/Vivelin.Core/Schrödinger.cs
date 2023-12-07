using System.Collections.Immutable;

namespace Vivelin;

public class Schrödinger<T>
{
    private static readonly bool s_isWeighted = typeof(T).IsAssignableTo(typeof(IWeighted));

    public Schrödinger(ReadOnlySpan<T> values)
    {
        Values = ImmutableList.Create(values);
    }

    public ImmutableList<T> Values { get; }

    public static implicit operator T(Schrödinger<T> value)
    {
        return value.Resolve();
    }

    public T Resolve() => Resolve(Random.Shared);

    public T Resolve(Random rng)
    {
        if (s_isWeighted)
        {
            return (T)Values.Cast<IWeighted>().WeightedSample(rng);
        }

        return Values.Sample(rng);
    }
}
