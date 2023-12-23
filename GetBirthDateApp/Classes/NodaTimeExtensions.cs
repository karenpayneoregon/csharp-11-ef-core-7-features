using NodaTime;

namespace GetBirthDateApp.Classes;

public static class NodaTimeExtensions
{
    public static LocalDate ToLocalDate(this DateTime dateTime) 
        => new(dateTime.Year, dateTime.Month, dateTime.Day);

}