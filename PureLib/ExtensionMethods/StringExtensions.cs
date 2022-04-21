using System.Text.Json;

namespace PureLib;

public static class StringExtensions
{
    /// <summary>
    /// Deserialized source string to the specified type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source">Serialized string.</param>
    /// <param name="jsonSerializerOptions">If left as <see langword="null"/> - defaults will be used.</param>
    /// <returns>Deserialized type or default of this type if failed.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="JsonException"/>
    /// <exception cref="NotSupportedException"/>
    public static T? Deserialize<T>(this string source, JsonSerializerOptions? jsonSerializerOptions = null)
    {
        return JsonSerializer.Deserialize<T>(source, jsonSerializerOptions);
    }
}
