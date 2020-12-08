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
        var x = GetFloat() * int.MaxValue;
        var y = GetFloat() * int.MaxValue;
        var z = GetFloat() * int.MaxValue;
        return new Vector3(x, y, z);
    }

    public Vector3 GetInsideSphere(float radius = 1)
    {
        return new Vector3(GetFloat(), GetFloat(), GetFloat()) * radius;
    }

    public Quaternion GetRotation()
    {
        return new Quaternion(GetFloat(), GetFloat(), GetFloat(), GetFloat());
    }

    public Quaternion GetRotationOnSurface(Vector3 surface)
    {
        return new Quaternion(surface.x, surface.y, surface.z, GetFloat());
    }
}