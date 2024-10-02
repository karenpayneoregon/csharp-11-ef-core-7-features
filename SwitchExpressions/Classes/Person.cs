using System;

namespace SwitchExpressions.Classes;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime DeathDate { get; set; }
    public void Deconstruct(out int dobMonth, out int dobDay, out int dobYear, out bool isMinor)
    {
        // does not account for leap years and should be in a class method
        int GetAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var value1 = (today.Year * 100 + today.Month) * 100 + today.Day;
            var value2 = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            return (value1 - value2) / 10000;
        }

        dobMonth = BirthDate.Month;
        dobDay = BirthDate.Day;
        dobYear = BirthDate.Year;
        isMinor = GetAge(BirthDate) < 18;
    }
}