#nullable disable

namespace NameOfSpecialSample.Models;

public partial class ContactDevices
{
    public int id { get; set; }

    public int? ContactId { get; set; }

    public int? PhoneTypeIdentifier { get; set; }

    public string PhoneNumber { get; set; }

    public virtual Contacts Contact { get; set; }

    public virtual PhoneType PhoneTypeIdentifierNavigation { get; set; }
}