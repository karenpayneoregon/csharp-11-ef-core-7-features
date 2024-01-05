using ProtoBuf;

namespace BogusExtendedApp.Models;

[ProtoContract]
public class ContactType
{
    [ProtoMember(1)]
    public int ContactTypeIdentifier { get; set; }
    [ProtoMember(2)]
    public string ContactTitle { get; set; }
    public override string ToString() => ContactTitle;

}