namespace GetBirthDateApp.Classes;
public static class GeneralExtensions
{
    public static int GetAge(this DateOnly dateOfBirth)
    {
        var today = DateTime.Today;

        var current = (today.Year * 100 + today.Month) * 100 + today.Day;
        var birth = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

        return (current - birth) / 10000;
    }
}
