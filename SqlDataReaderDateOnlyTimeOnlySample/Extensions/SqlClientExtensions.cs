using Microsoft.Data.SqlClient;

namespace SqlDataReaderDateOnlyTimeOnlySample.Extensions;

internal static class SqlClientExtensions
{

    public static DateOnly GetDateOnly(this SqlDataReader reader, int index)
        => reader.GetFieldValue<DateOnly>(index);

    public static async Task<DateOnly> GetDateOnlyAsync(this SqlDataReader reader, int index)
        => await reader.GetFieldValueAsync<DateOnly>(index);

    public static async Task<DateTime> GetDateTimeAsync(this SqlDataReader reader, int index)
        => await reader.GetFieldValueAsync<DateTime>(index);

    public static async Task<DateTimeOffset> GetDateTimeOffsetAsync(this SqlDataReader reader, int index)
        => await reader.GetFieldValueAsync<DateTimeOffset>(index);

    public static async Task<string> GetStringAsync(this SqlDataReader reader, int index)
        => await reader.GetFieldValueAsync<string>(index);

    public static async Task<int> GetIntAsync(this SqlDataReader reader, int index)
        => await reader.GetFieldValueAsync<int>(index);

    public static async Task<decimal> GetDecimalAsync(this SqlDataReader reader, int index)
        => await reader.GetFieldValueAsync<decimal>(index);

    public static async Task<double> GetDoubleAsync(this SqlDataReader reader, int index)
        => await reader.GetFieldValueAsync<double>(index);

    public static TimeOnly ToTimeOnly(this TimeSpan sender)
        => TimeOnly.FromTimeSpan(sender);

    public static TimeOnly GetTimeOnly(this SqlDataReader reader, int index)
        => reader.GetFieldValue<TimeOnly>(index);

    public static async Task<TimeOnly> GetTimeOnlyAsync(this SqlDataReader reader, int index)
        => await reader.GetFieldValueAsync<TimeOnly>(index);
}