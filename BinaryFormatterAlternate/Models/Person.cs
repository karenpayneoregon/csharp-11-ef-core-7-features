using BinaryFormatterAlternate.Interfaces;
using ProtoBuf;

namespace BinaryFormatterAlternate.Models;

[ProtoContract(ImplicitFields = ImplicitFields.AllFields)]
public class Person : IPerson
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public string SSN { get; set; }
    public Address Address { get; set; }
}