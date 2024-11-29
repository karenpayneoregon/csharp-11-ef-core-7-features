using BinaryFormatterAlternate.Models;

namespace BinaryFormatterAlternate.Interfaces;

public interface IPerson
{
    int Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    DateOnly BirthDate { get; set; }
    string SSN { get; set; }
    Address Address { get; set; }
}