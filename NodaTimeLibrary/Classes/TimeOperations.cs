using NodaTime;
using NodaTime.TimeZones;

namespace NodaTimeLibrary.Classes;
/// <summary>
///
/// Patterns for Offset values
/// https://nodatime.org/3.1.x/userguide/offset-patterns
///
/// Time zone list
/// https://nodatime.org/TimeZones
/// https://gist.github.com/jrolstad/5ca7d78dbfe182d7c1be
/// </summary>
public static class TimeOperations
{
    /// <summary>
    /// Gets the time zone offset and whether daylight savings is in effect for the specified time zone and UTC date and time.
    /// </summary>
    /// <param name="timeZoneId">The identifier of the time zone.</param>
    /// <param name="dateTimeUtc">The UTC date and time.</param>
    /// <returns>A tuple containing the time zone offset as a string and a boolean indicating whether daylight savings is in effect.</returns>
    public static (string offset, bool daylightSavings) TimeZoneOffset(string timeZoneId, DateTime dateTimeUtc)
    {

        Instant instant = Instant.FromDateTimeUtc(dateTimeUtc);
        DateTimeZone zone = DateTimeZoneProviders.Tzdb[timeZoneId];

        ZonedDateTime dateTime = new(instant, zone);
        var daylightSavings = dateTime.IsDaylightSavingsTime();

        Offset offset = daylightSavings ? zone.MinOffset : zone.MaxOffset;

        return (offset.ToString("m", null), daylightSavings);
    }

    public static TimeSpan GetTimeZoneOffset(string timeZoneId, DateTime dateTimeUtc)
    {
        Instant instant = Instant.FromDateTimeUtc(dateTimeUtc);
        DateTimeZone zone = DateTimeZoneProviders.Tzdb[timeZoneId];
        Offset offset = zone.GetUtcOffset(instant);
        return offset.ToTimeSpan();
    }

    /// <summary>
    /// Determines whether the specified date and time is during daylight saving time in the given time zone.
    /// </summary>
    /// <param name="zonedDateTime">The date and time to check.</param>
    /// <returns>True if the specified date and time is during daylight saving time; otherwise, false.</returns>
    public static bool IsDaylightSavingsTime(this ZonedDateTime zonedDateTime)
    {
        var instant = zonedDateTime.ToInstant();
        var zoneInterval = zonedDateTime.Zone.GetZoneInterval(instant);
        return zoneInterval.Savings != Offset.Zero;
    }

    /// <summary>
    /// Gets the current system date and time in the specified time zone.
    /// </summary>
    /// <param name="zone">The time zone identifier. Default is "US/Pacific".</param>
    /// <returns>The current system date and time in the specified time zone.</returns>
    public static DateTime GetSysDateTimeNow(string zone = "US/Pacific")
    {
        Instant now = SystemClock.Instance.GetCurrentInstant();
        return now.InZone(DateTimeZoneProviders.Tzdb[zone]).ToDateTimeUnspecified();
    }

    /// <summary>
    /// Gets all the time zones for a given country code.
    /// </summary>
    /// <param name="countryCode">The country code. Default is "US".</param>
    /// <returns>A list of TzdbZoneLocation objects representing the time zones.</returns>
    public static List<TzdbZoneLocation> GetAllTimeZones(string countryCode = "US") =>
        (TzdbDateTimeZoneSource.Default.ZoneLocations ?? Enumerable.Empty<TzdbZoneLocation>().ToList())
        .Where(x => x.CountryCode == countryCode)
        .ToList();
}