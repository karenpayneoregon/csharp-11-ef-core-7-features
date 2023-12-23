using NodaTime;

namespace GetBirthDateApp.Classes;
public class NodaTimeOperations
{
    public static int GetAge(LocalDate dateOfBirth, string selectedZone)
    {

        Instant now = SystemClock.Instance.GetCurrentInstant();

        /*
         * The target time zone is important.
         * It should align with the *current physical location* of the person
         */
        DateTimeZone zone = DateTimeZoneProviders.Tzdb[selectedZone];

        LocalDate today = now.InZone(zone).Date;

        Period period = Period.Between(dateOfBirth, today, PeriodUnits.Years);

        return (int)period.Years;
    }
}