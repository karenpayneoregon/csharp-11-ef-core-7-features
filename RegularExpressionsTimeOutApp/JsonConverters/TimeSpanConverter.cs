using System.Text.Json;
using System.Text.Json.Serialization;

namespace RegularExpressionsTimeOutApp.JsonConverters;

/// <summary>
/// Converts <see cref="TimeSpan"/> objects to and from JSON strings using a specific format.
/// </summary>
public class TimeSpanConverter : JsonConverter<TimeSpan>
{
    private const string Format = @"hh\:mm\:ss";

    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException("Expected string for TimeSpan");
        }

        string timeSpanString = reader.GetString();
        if (TimeSpan.TryParseExact(timeSpanString, Format, null, out var timeSpan))
        {
            return timeSpan;
        }

        throw new JsonException($"Invalid TimeSpan format, expected {Format}");
    }

    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format));
    }
}