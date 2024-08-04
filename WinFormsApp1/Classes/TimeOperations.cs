using NodaTime;
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
    public static string TimeZoneOffset(string timeZoneId, DateTime dateTimeUtc)
    {

        Instant instant = Instant.FromDateTimeUtc(dateTimeUtc);
        DateTimeZone zone = DateTimeZoneProviders.Tzdb[timeZoneId];

        ZonedDateTime dateTime = new ZonedDateTime(instant, zone);
        var daylightSavings = dateTime.IsDaylightSavingsTime();
        //Offset offset = zone.GetUtcOffset(instant);
        Offset offset = daylightSavings ? zone.MinOffset : zone.MaxOffset;
        return offset.ToString("m", null);
    }

    public static bool IsDaylightSavingsTime(this ZonedDateTime zonedDateTime)
    {
        var instant = zonedDateTime.ToInstant();
        var zoneInterval = zonedDateTime.Zone.GetZoneInterval(instant);
        return zoneInterval.Savings != Offset.Zero;
    }

    public static DateTime GetSysDateTimeNow(string zone = "US/Pacific")
    {
        Instant now = SystemClock.Instance.GetCurrentInstant();
        return now.InZone(DateTimeZoneProviders.Tzdb[zone]).ToDateTimeUnspecified();
    }
}

public class UnitedStates
{
    public EastCoast East { get; set; } = new();
    public WestCoast West { get; set; } = new();
}

public class EastCoast
{
    public string Offset()
    {
        const string timeZoneId = "US/Eastern";
        var offset = TimeZoneOffset(timeZoneId, DateTime.SpecifyKind(GetSysDateTimeNow(timeZoneId), DateTimeKind.Utc));
        return offset;
    }


}

public class WestCoast
{
    public string Offset()
    {
        const string timeZoneId = "US/Pacific";
        var offset = TimeZoneOffset(timeZoneId, DateTime.SpecifyKind(GetSysDateTimeNow(), DateTimeKind.Utc));
        return offset;
    }
}

public class Mexico
{
    public static string CancunOffset()
    {
        const string timeZoneId = "America/Cancun";
        var offset = TimeZoneOffset(timeZoneId, DateTime.SpecifyKind(GetSysDateTimeNow(timeZoneId), DateTimeKind.Utc));
        return offset;
    }
}