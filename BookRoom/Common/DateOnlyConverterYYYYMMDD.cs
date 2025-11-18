using BookRoom.Logics;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookRoom.Common;

public class DateOnlyConverterYYYYMMDD : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString() ?? string.Empty;
        return DateTime.ParseExact(value, GeneralSettings.DateFormat, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(GeneralSettings.DateFormat));
    }
}
