// ReSharper disable CheckNamespace

using UnityEngine;

/// <summary>
/// Multiplicative Congruence generator using a modulus of 2^31
/// </summary>
public class FastRandom : IRandom
{
    private const ulong Modulus = 2147483647; //2^31
    private const ulong Multiplier = 1132489760;
    private const double ModulusReciprocal = 1.0 / Modulus;

    private ulong _next;

    public FastRandom()
    {
        NewSeed();
    }

    public FastRandom(int seed)
    {
        NewSeed(seed);
    }

    public void NewSeed()
    {
        _next = (ulong) RandomSeed.Crypto();
    }
    
    /// <inheritdoc />
    /// <remarks>If the seed value is zero, it is set to one.</remarks>
    public void NewSeed(int seed)
    {
        if (seed == 0)
            seed = 1;

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

    public Vector2 GetVector2()
    {
        var x = GetFloat() * int.MaxValue;
        var y = GetFloat() * int.MaxValue;
        return new Vector2(x, y);
    }

    public Vector2 GetInsideCircle(float radius = 1)
    {
        return new Vector2(GetFloat(), GetFloat()) * radius;
    }

    public Vector3 GetVector3()
    {
        var x = Range(int.MinValue, int.MaxValue);
        var y = Range(int.MinValue, int.MaxValue);
        var z = Range(int.MinValue, int.MaxValue);
        return new Vector3(x, y, z);
    }

    public Vector3 GetInsideSphere(float radius = 1)
    {
        return new Vector3(GetFloat(), GetFloat(), GetFloat()) * radius;
    }

    public Quaternion GetRotation()
    {
        return GetRotationOnSurface(GetVector3());
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