using ProtoBuf;

namespace BinaryFormatterAlternate.Models;

[ProtoContract(ImplicitFields = ImplicitFields.AllFields)]
public class Address
{
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}