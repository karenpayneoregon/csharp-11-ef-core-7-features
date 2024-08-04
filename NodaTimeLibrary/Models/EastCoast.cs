using NodaTimeLibrary.Classes;

namespace NodaTimeLibrary.Models;

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
        TimeOperations.TimeZoneOffset(_timeZoneId, 
            DateTime.SpecifyKind(TimeOperations.GetSysDateTimeNow(_timeZoneId), 
                DateTimeKind.Utc)).offset;

    /// <summary>
    /// Determines whether the East Coast time zone is currently in daylight saving time.
    /// </summary>
    /// <returns>True if the East Coast time zone is currently in daylight saving time; otherwise, false.</returns>
    public bool DaylightSavingsSupported =>
        TimeOperations.TimeZoneOffset(_timeZoneId, 
            DateTime.SpecifyKind(TimeOperations.GetSysDateTimeNow(_timeZoneId), 
                DateTimeKind.Utc)).daylightSavings;
}