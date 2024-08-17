using NodaTimeLibrary.Classes;

namespace NodaTimeLibrary.Models;

public class WestCoast
{
    private string _timeZoneId => "US/Pacific";

    /// <summary>
    /// Gets the offset of the West Coast time zone.
    /// </summary>
    /// <returns>The offset of the West Coast time zone.</returns>
    public string Offset =>
        TimeOperations.TimeZoneOffset(_timeZoneId, 
            DateTime.SpecifyKind(TimeOperations.GetSysDateTimeNow(), 
                DateTimeKind.Utc)).offset;

    /// <summary>
    /// Gets the time span representing the offset of the West Coast time zone.
    /// </summary>
    /// <returns>The time span representing the offset of the West Coast time zone.</returns>
    public TimeSpan GetTimeSpan() =>
        TimeOperations.GetTimeZoneOffset(_timeZoneId,
            DateTime.SpecifyKind(TimeOperations.GetSysDateTimeNow(_timeZoneId), DateTimeKind.Utc));
    /// <summary>
    /// Determines whether the West Coast time zone is currently in daylight saving time.
    /// </summary>
    /// <returns>True if the West Coast time zone is currently in daylight saving time; otherwise, false.</returns>
    public bool DaylightSavingsSupported =>
        TimeOperations.TimeZoneOffset(_timeZoneId, 
            DateTime.SpecifyKind(TimeOperations.GetSysDateTimeNow(_timeZoneId), 
                DateTimeKind.Utc)).daylightSavings;
}