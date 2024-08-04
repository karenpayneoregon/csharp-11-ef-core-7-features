using NodaTime;
using NodaTime.TimeZones;
using static WinFormsApp1.Classes.TimeOperations;

namespace WinFormsApp1.Classes;
/// <summary>
///
/// Patterns for Offset values
/// https://nodatime.org/3.1.x/userguide/offset-patterns
///
/// Time zone list
/// https://nodatime.org/TimeZones
/// https://gist.github.com/jrolstad/5ca7d78dbfe182d7c1be
/// </summary>
internal static class TimeOperations
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

/// <summary>
/// Represents the United States with its East Coast and West Coast time zones.
/// </summary>
public class UnitedStates
{
    /// <summary>
    /// Gets or sets the East Coast time zone.
    /// </summary>  
    public EastCoast EastCoast { get; init; } = new();

    /// <summary>
    /// Gets or sets the West Coast time zone.
    /// </summary>
    public WestCoast WestCoast { get; init; } = new();
}

/// <summary>
/// Represents the East Coast time zone.
/// </summary>
public class EastCoast
{
    private string _timeZoneId => "US/Eastern";

    /// <summary>
    /// Gets the offset of the East Coast time zone.
    /// </summary>
    /// <returns>The offset of the East Coast time zone.</returns>
    public string Offset =>
        TimeZoneOffset(_timeZoneId, DateTime.SpecifyKind(GetSysDateTimeNow(_timeZoneId), DateTimeKind.Utc)).offset;

    /// <summary>
    /// Determines whether the East Coast time zone is currently in daylight saving time.
    /// </summary>
    /// <returns>True if the East Coast time zone is currently in daylight saving time; otherwise, false.</returns>
    public bool DaylightSavingsSupported =>
        TimeZoneOffset(_timeZoneId, DateTime.SpecifyKind(GetSysDateTimeNow(_timeZoneId), DateTimeKind.Utc)).daylightSavings;
}

public class WestCoast
{
    private string _timeZoneId => "US/Pacific";

    /// <summary>
    /// Gets the offset of the West Coast time zone.
    /// </summary>
    /// <returns>The offset of the West Coast time zone.</returns>
    public string Offset =>
        TimeZoneOffset(_timeZoneId, DateTime.SpecifyKind(GetSysDateTimeNow(), DateTimeKind.Utc)).offset;

    /// <summary>
    /// Determines whether the West Coast time zone is currently in daylight saving time.
    /// </summary>
    /// <returns>True if the West Coast time zone is currently in daylight saving time; otherwise, false.</returns>
    public bool DaylightSavingsSupported =>
        TimeZoneOffset(_timeZoneId, DateTime.SpecifyKind(GetSysDateTimeNow(_timeZoneId), DateTimeKind.Utc)).daylightSavings;
}

public class Mexico
{
    public SeaCoast SeaCoast { get; init; } = new();

}

public class SeaCoast
{
    private string _timeZoneId => "America/Cancun";

    /// <summary>
    /// Gets the offset of the West Coast time zone.
    /// </summary>
    /// <returns>The offset of the West Coast time zone.</returns>
    public string Offset =>
        TimeZoneOffset(_timeZoneId, DateTime.SpecifyKind(GetSysDateTimeNow(), DateTimeKind.Utc)).offset;

    /// <summary>
    /// Determines whether the West Coast time zone is currently in daylight saving time.
    /// </summary>
    /// <returns>True if the West Coast time zone is currently in daylight saving time; otherwise, false.</returns>
    public bool DaylightSavingsSupported() =>
        TimeZoneOffset(_timeZoneId, DateTime.SpecifyKind(GetSysDateTimeNow(_timeZoneId), DateTimeKind.Utc)).daylightSavings;
}