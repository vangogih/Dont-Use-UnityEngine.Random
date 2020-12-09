// ReSharper disable CheckNamespace

using System;
using UnityEngine;
using Random = System.Random;

public class SystemRandom : IRandom
{
    private Random _rnd;

    public SystemRandom()
    {
        _rnd = new Random(RandomSeed.Crypto());
    }

    public SystemRandom(int seed)
    {
        _rnd = new Random(seed);
    }

    public void NewSeed()
    {
        _rnd = new Random(DateTime.UtcNow.GetHashCode());
    }

    public void NewSeed(int seed)
    {
        _rnd = new Random(seed);
    }

    public float GetFloat()
    {
        return (float) _rnd.NextDouble();
    }

    public int GetInt()
    {
        return _rnd.Next();
    }

    public float Range(float min, float max)
    {
        return GetFloat() * (max - min) + min;
    }

    public int Range(int min, int max)
    {
        return _rnd.Next(min, max);
    }

    public Vector2 GetVector2()
    {
        var x = Range((float) int.MinValue, int.MaxValue);
        var y = Range((float) int.MinValue, int.MaxValue);
        return new Vector2(x, y);
    }

    public Vector2 GetInsideCircle(float radius = 1)
    {
        var x = GetFloat() * radius;
        var y = GetFloat() * radius;
        return new Vector2(x, y);
    }

    public Vector3 GetVector3()
    {
        var x = Range((float) int.MinValue, int.MaxValue);
        var y = Range((float) int.MinValue, int.MaxValue);
        var z = Range((float) int.MinValue, int.MaxValue);
        return new Vector3(x, y, z);
    }

    public Vector3 GetInsideSphere(float radius = 1)
    {
        var x = GetFloat() * radius;
        var y = GetFloat() * radius;
        var z = GetFloat() * radius;
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
}