// ReSharper disable CheckNamespace

using UnityEngine;

public interface IRandom
{
    int Seed { get; }
    /// <summary>Create new random with new unique seed</summary>
    void NewSeed();

    /// <summary>Create new random sequence based on new seed</summary>
    void NewSeed(int seed);

    /// <returns>A random float number between 0.0f (inclusive) and 1.0f (inclusive)</returns>
    float GetFloat();

    /// <returns>A random int number between int.MinValue (inclusive) and int.MaxValue (inclusive)</returns>
    int GetInt();

    /// <returns>A random float number between min (inclusive) and max (inclusive) values</returns>
    float Range(float min, float max);

    /// <returns>A random int number between int.MinValue (inclusive) and int.MaxValue (inclusive) values</returns>
    int Range(int min, int max);

    /// <returns>A point inside the circle with given radius</returns>
    Vector2 GetInsideCircle(float radius);

    /// <returns>A point inside the sphere with given radius</returns>
    Vector3 GetInsideSphere(float radius);

    /// <returns>A random Quaternion struct where X,Y,Z,W has numbers in 0.0f .. 1.0f (inclusive)</returns>
    Quaternion GetRotation();

    /// <returns>A random Quaternion struct where W has numbers in 0.0f .. 1.0f (inclusive)</returns>
    Quaternion GetRotationOnSurface(Vector3 surface);
}