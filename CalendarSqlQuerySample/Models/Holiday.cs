namespace CalendarSqlQuerySample.Models;
internal class Holiday
{
    public DateOnly CalendarDate { get; set; }
    public string Description { get; set; }
    public int CalendarMonth { get; set; }
    public string Month { get; set; }
    public int Day { get; set; }
    public string DayOfWeekName { get; set; }
    public string BusinessDay { get; set; }
    public string Weekday { get; set; }
}
