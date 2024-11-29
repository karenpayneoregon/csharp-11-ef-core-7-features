using ProtoBuf;

namespace BinaryFormatterAlternate.Models;

[ProtoContract(
    ImplicitFields = ImplicitFields.AllFields, 
    SkipConstructor = true)]
public class Human
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public string SSN { get; set; }
    public Address Address { get; set; }

    public Human()
    {
        
    }
}