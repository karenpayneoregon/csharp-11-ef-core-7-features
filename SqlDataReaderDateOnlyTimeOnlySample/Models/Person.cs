#nullable disable
namespace SqlDataReaderDateOnlyTimeOnlySample.Models;

public class Person
{
    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly? BirthDate { get; set; } 
}