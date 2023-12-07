using System.Collections.Immutable;

namespace Vivelin;

public class Schrödinger<T>
{
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
        var index = rng.Next(Values.Count);
        return Values[index];
    }
}
