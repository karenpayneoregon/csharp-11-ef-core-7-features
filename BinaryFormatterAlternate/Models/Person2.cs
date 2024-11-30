namespace BinaryFormatterAlternate.Models;


/// <summary>
/// Represents a person with identifiable information such as ID, name, birthdate, social security number, and address.
/// Used in DataContractSerializerOperations
/// </summary>
public class Person2
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string SSN { get; set; }
    public Address Address { get; set; }
}