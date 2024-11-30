using BinaryFormatterAlternate.Interfaces;

namespace BinaryFormatterAlternate.Models;

/// <summary>
/// For Json serialization and deserialization using System.Text.Json
/// </summary>
public class Person1 : IPerson
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public string SSN { get; set; }
    public Address Address { get; set; }
}