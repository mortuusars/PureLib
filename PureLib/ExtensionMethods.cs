﻿using System.Text.Json;

namespace PureLib;

public static class ExtensionMethods
{
    /// <summary>
    /// Casts object to specified type.
    /// </summary>
    /// <typeparam name="T">Type to cast to.</typeparam>
    /// <param name="obj">Source object.</param>
    /// <exception cref="InvalidCastException"/>
    public static T CastTo<T>(this object obj)
    {
        return (T)obj;
    }

    /// <summary>
    /// Serializes object to json string.
    /// </summary>
    /// <returns> Indented serialized string.</returns>
    /// <exception cref="NotSupportedException"/>
    public static string Serialize<T>(this T value)
    {
        return JsonSerializer.Serialize(value, new JsonSerializerOptions() { WriteIndented = true });
    }

    /// <summary>
    /// Serializes value to json string, catching exceptions.
    /// </summary>
    /// <param name="value">Input object.</param>
    /// <param name="json">Result of the serialization. <see langword="null"/> if serialization fails.</param>
    /// <returns><see langword="true"/> if serialization was successful. Otherwise <see langword="false"/>.</returns>
    public static bool TrySerialize<T>(this T value, out string json)
    {
        try
        {
            json = Serialize(value);
            return true;
        }
        catch (Exception)
        {
            json = null!;
            return false;
        }
    }

    /// <summary>
    /// Serializes object to json string using provided serializer options.
    /// </summary>
    /// <returns>Serialized string.</returns>
    /// <exception cref="NotSupportedException"/>
    public static string Serialize<T>(this T value, JsonSerializerOptions options)
    {
        return JsonSerializer.Serialize(value, options);
    }

    /// <summary>
    /// Serializes value to json string using the provided serializer options, catching exceptions.
    /// </summary>
    /// <param name="value">Input object.</param>
    /// <param name="json">Result of the serialization. <see langword="null"/> if serialization fails.</param>
    /// <returns><see langword="true"/> if serialization was successful. Otherwise <see langword="false"/>.</returns>
    public static bool TrySerialize<T>(this T value, JsonSerializerOptions options, out string json)
    {
        try
        {
            json = Serialize(value, options);
            return true;
        }
        catch (Exception)
        {
            json = null!;
            return false;
        }
    }

    /// <summary>
    /// Deserializes input json string to object.
    /// </summary>
    /// <typeparam name="T">Resulting type.</typeparam>
    /// <param name="json">Input json string.</param>
    /// <returns>Deserialized object.</returns>
    /// <exception cref="JsonException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="NotSupportedException"/>
    public static T? Deserialize<T>(this string json)
    {
        return JsonSerializer.Deserialize<T>(json);
    }

    /// <summary>
    /// Deserializes input json string to object using the provided options..
    /// </summary>
    /// <typeparam name="T">Resulting type.</typeparam>
    /// <param name="json">Input json string.</param>
    /// <returns>Deserialized object.</returns>
    /// <exception cref="JsonException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="NotSupportedException"/>
    public static T? Deserialize<T>(this string json, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize<T>(json, options);
    }
}
