namespace Vivelin;

public readonly record struct Weighted<T>(T Value, double Weight) : IWeighted
{
    public Weighted(T value) 
        : this(value, 1.0) { }

    public static implicit operator T(Weighted<T> weighted)
        => weighted.Value;
}
