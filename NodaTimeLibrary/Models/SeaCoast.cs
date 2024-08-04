using NodaTimeLibrary.Classes;

namespace NodaTimeLibrary.Models;

public class SeaCoast
{
    private string _timeZoneId => "America/Cancun";

    /// <summary>
    /// Gets the offset of the West Coast time zone.
    /// </summary>
    /// <returns>The offset of the West Coast time zone.</returns>
    public string Offset =>
        TimeOperations.TimeZoneOffset(_timeZoneId, 
            DateTime.SpecifyKind(TimeOperations.GetSysDateTimeNow(), 
                DateTimeKind.Utc)).offset;

    /// <summary>
    /// Determines whether the West Coast time zone is currently in daylight saving time.
    /// </summary>
    /// <returns>True if the West Coast time zone is currently in daylight saving time; otherwise, false.</returns>
    public bool DaylightSavingsSupported =>
        TimeOperations.TimeZoneOffset(_timeZoneId, 
            DateTime.SpecifyKind(TimeOperations.GetSysDateTimeNow(_timeZoneId), 
                DateTimeKind.Utc)).daylightSavings;
}