namespace TimeApp;

public class Calendar(TimeProvider timeProvider)
{
    public bool IsMonday()
        => timeProvider.GetLocalNow().DayOfWeek == DayOfWeek.Monday;
    public bool IsTuesday()
        => timeProvider.GetLocalNow().DayOfWeek == DayOfWeek.Tuesday;
    public bool IsWednesday()
        => timeProvider.GetLocalNow().DayOfWeek == DayOfWeek.Wednesday;
    public bool IsThursday()
        => timeProvider.GetLocalNow().DayOfWeek == DayOfWeek.Thursday;
    public bool IsFriday()
        => timeProvider.GetLocalNow().DayOfWeek == DayOfWeek.Friday;
    public bool IsSaturday()
        => timeProvider.GetLocalNow().DayOfWeek == DayOfWeek.Saturday;
    public bool IsSunday()
        => timeProvider.GetLocalNow().DayOfWeek == DayOfWeek.Sunday;
}