using FormattableStringEmailSample.Interfaces;

namespace FormattableStringEmailSample.Models;

public class Person : IPerson
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
}