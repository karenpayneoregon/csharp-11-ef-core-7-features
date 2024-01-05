
using ProtoBuf;

namespace BogusExtendedApp.Models;

[ProtoContract]
public class Contact
{
    [ProtoMember(1)]
    public int Id { get; set; }
    [ProtoMember(2)]
    public string FirstName { get; set; }
    [ProtoMember(3)]
    public string LastName { get; set; }
    [ProtoMember(4)]
    public int ContactTypeIdentifier { get; set; }
    [ProtoMember(5)]
    public ContactType ContactType { get; set; } = new();
    public override string ToString() => $"{FirstName} {LastName}";
    
    public Contact(int id)
    {
        Id = id;
    }

    public Contact()
    {

    }

}