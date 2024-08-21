namespace FormattableStringEmailSample.Interfaces;

public interface IPerson
{
    int Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    DateOnly BirthDate { get; set; }
}