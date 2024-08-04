using NodaTime;

namespace NodaTimeLibrary.Classes;
public class PeriodOperations
{
    /// <summary>
    /// Calculates the period between a birthdate and a given date in years, months, and days.
    /// </summary>
    /// <param name="birthDate">The birthdate.</param>
    /// <param name="date">The date to calculate the period to.</param>
    /// <returns>The period between the birthdate and the given date.</returns>
    public static Period YearsOld(DateOnly birthDate, DateOnly date) =>
        Period.Between(LocalDate.FromDateOnly(birthDate), LocalDate.FromDateOnly(date),
            PeriodUnits.Years |
            PeriodUnits.Months |
            PeriodUnits.Days);
}
