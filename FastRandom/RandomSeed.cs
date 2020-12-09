// ReSharper disable CheckNamespace

using System;
using System.Security.Cryptography;

public static class RandomSeed
{
    private static readonly RandomNumberGenerator RandomNumberGenerator = RandomNumberGenerator.Create();

    public static int Time()
    {
        return DateTime.UtcNow.GetHashCode();
    }

    public static int Guid()
    {
        return Environment.TickCount ^ System.Guid.NewGuid().GetHashCode();
    }

    public static int Crypto()
    {
        var bytes = new byte[4];
        RandomNumberGenerator.GetBytes(bytes);
        return BitConverter.ToInt32(bytes, 0);
    }
}