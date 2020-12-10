// ReSharper disable CheckNamespace

using UnityEngine;

/// <summary>
/// Multiplicative Congruence generator using a modulus of 2^31
/// </summary>
public sealed class FastRandom : IRandom
{
    public int Seed { get; private set; }

    private const ulong Modulus = 2147483647; //2^31
    private const ulong Multiplier = 1132489760;
    private const double ModulusReciprocal = 1.0 / Modulus;

    private ulong _next;

    public FastRandom()
        : this(RandomSeed.Crypto()) { }

    public FastRandom(int seed)
    {
        NewSeed(seed);
    }
    
    public void NewSeed()
    {
        NewSeed(RandomSeed.Crypto());
    }

    /// <inheritdoc />
    /// <remarks>If the seed value is zero, it is set to one.</remarks>
    public void NewSeed(int seed)
    {
        if (seed == 0)
            seed = 1;

        Seed = seed;
        _next = (ulong) seed % Modulus;
    }

    public float GetFloat()
    {
        return (float) InternalSample();
    }

    public int GetInt()
    {
        return Range(int.MinValue, int.MaxValue);
    }

    public float Range(float min, float max)
    {
        return (float) (InternalSample() * (max - min) + min);
    }

    public int Range(int min, int max)
    {
        return (int) (InternalSample() * (max - min) + min);
    }

    public Vector2 GetInsideCircle(float radius = 1)
    {
        var x = Range(-1f, 1f) * radius;
        var y = Range(-1f, 1f) * radius;
        return new Vector2(x, y);
    }

    public Vector3 GetInsideSphere(float radius = 1)
    {
        var x = Range(-1f, 1f) * radius;
        var y = Range(-1f, 1f) * radius;
        var z = Range(-1f, 1f) * radius;
        return new Vector3(x, y, z);
    }

    public Quaternion GetRotation()
    {
        return GetRotationOnSurface(GetInsideSphere());
    }

    public Quaternion GetRotationOnSurface(Vector3 surface)
    {
        return new Quaternion(surface.x, surface.y, surface.z, GetFloat());
    }

    private double InternalSample()
    {
        var ret = _next * ModulusReciprocal;
        _next = _next * Multiplier % Modulus;
        return ret;
    }
}