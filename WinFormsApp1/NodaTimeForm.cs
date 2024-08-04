using NodaTime;
using System.Diagnostics;
using NodaTime.Extensions;
using NodaTime.Text;
using NodaTime.TimeZones;
using WinFormsApp1.Classes;

// ReSharper disable SuggestVarOrType_SimpleTypes

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
        var period1 = Period.Between(startDate, endDate);

    }
    private void betweenPeriodsButton_Click(object sender, EventArgs e)
    {
        var period = YearsOld(new DateOnly(1956, 9, 24), new DateOnly(2024, 8, 26));
        Debug.WriteLine($"{period.Years} years  {period.Months} months {period.Days} days");
    }


    /// <summary>
    /// Calculates the period between a birthdate and a given date in years, months, and days.
    /// </summary>
    /// <param name="birthDate">The birthdate.</param>
    /// <param name="date">The date to calculate the period to.</param>
    /// <returns>The period between the birthdate and the given date.</returns>
    private static Period YearsOld(DateOnly birthDate, DateOnly date)
    {
        var birth = LocalDate.FromDateOnly(birthDate);
        var now = LocalDate.FromDateOnly(date);
        return Period.Between(LocalDate.FromDateOnly(birthDate), LocalDate.FromDateOnly(date),
            PeriodUnits.Years |
            PeriodUnits.Months |
            PeriodUnits.Days);
    }

    public static TimeSpan GetTimeZoneOffset(string timeZoneId, DateTime dateTimeUtc)
    {
        Instant instant = Instant.FromDateTimeUtc(dateTimeUtc);
        DateTimeZone zone = DateTimeZoneProviders.Tzdb[timeZoneId];
        Offset offset = zone.GetUtcOffset(instant);
        var test = offset.ToString("m", null);
        return offset.ToTimeSpan();
    }

    public static string GetTimeZoneOffset1(string timeZoneId, DateTime dateTimeUtc)
    {
        Instant instant = Instant.FromDateTimeUtc(dateTimeUtc);
        DateTimeZone zone = DateTimeZoneProviders.Tzdb[timeZoneId];
        Offset offset = zone.GetUtcOffset(instant);
        return offset.ToString("m", null);

    }
    private void asiaButton_Click(object sender, EventArgs e)
    {
        //Instant now = SystemClock.Instance.GetCurrentInstant();
        //ZonedDateTime nowInIsoUtc = now.InUtc();

        //var pacificNorthWest = GetSysDateTimeNow();

        var cancun = GetSysDateTimeNow("America/Cancun");
        var offset = GetTimeZoneOffset("America/Cancun", 
            DateTime.SpecifyKind(cancun, DateTimeKind.Utc));


        Debug.WriteLine(offset.Hours);
        Debug.WriteLine(offset.ToString(@"hh\:mm"));

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

    private void button6_Click(object sender, EventArgs e)
    {


                UnitedStates us = new();
                Debug.WriteLine($"  Eastern: {us.EastCoast.Offset}");
                Debug.WriteLine($"           {us.EastCoast.DaylightSavingsSupported}");
                Debug.WriteLine($"  Western: {us.WestCoast.Offset}");
                Debug.WriteLine($"           {us.WestCoast.DaylightSavingsSupported}");

                Mexico mx = new();
                Debug.WriteLine($"Sea Coast: {mx.SeaCoast.Offset}");
                Debug.WriteLine($"           {mx.SeaCoast.DaylightSavingsSupported()}");





    }

    private void button7_Click(object sender, EventArgs e)
    {
        var readOnlyCollection = TimeZoneInfo.GetSystemTimeZones();

    }

}

