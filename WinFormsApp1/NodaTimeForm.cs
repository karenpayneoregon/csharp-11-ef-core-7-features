using NodaTime;
using System.Diagnostics;
using NodaTime.Extensions;

namespace WinFormsApp1;
public partial class NodaTimeForm : Form
{
    public NodaTimeForm() { InitializeComponent(); }
    private void betweenDaysButton_Click(object sender, EventArgs e)
    {
        Instant now = SystemClock.Instance.GetCurrentInstant();
        ZonedDateTime nowInIsoUtc = now.InUtc();

        LocalDate startDate = new(2024, 2, 9);
        LocalDate endDate = startDate.PlusWeeks(1);

        int period = Period.DaysBetween(startDate, endDate);
        Period period1 = Period.Between(startDate, endDate);

    }
    private void betweenPeriodsButton_Click(object sender, EventArgs e)
    {
        LocalDate birthday = new(1956, 9, 24);
        LocalDate today = new(2024, 2, 9);
        Period period = Period.Between(birthday, today,
            PeriodUnits.Years |
            PeriodUnits.Months |
            PeriodUnits.Days);

        Debug.WriteLine($"{period.Years} years  {period.Months} months {period.Days} days");
    }
    private void asiaButton_Click(object sender, EventArgs e)
    {
        Instant now = SystemClock.Instance.GetCurrentInstant();
        ZonedDateTime nowInIsoUtc = now.InUtc();

        var dateTime1 = GetSysDateTimeNow("Asia/Shanghai");
        var dateTime2 = GetSysDateTimeNow();
    }
    public DateTime GetSysDateTimeNow(string zone = "US/Pacific")
    {
        Instant now = SystemClock.Instance.GetCurrentInstant();
        var shanghaiZone = DateTimeZoneProviders.Tzdb[zone];
        return now.InZone(shanghaiZone).ToDateTimeUnspecified();
    }
    private void timeZonesButton_Click(object sender, EventArgs e)
    {
        IDateTimeZoneProvider provider = DateTimeZoneProviders.Tzdb;
        var result = provider.GetAllZones();
    }
    private void fromLocalDateTimeToAnotherDateTimeButton_Click(object sender, EventArgs e)
    {
        var clock = SystemClock.Instance;
        var zoned = clock.InZone(DateTimeZoneProviders.Tzdb["Europe/London"]);
        LocalDate date = zoned.GetCurrentDate();
        LocalTime time = zoned.GetCurrentTimeOfDay();
    }
}

