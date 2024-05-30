#nullable disable

namespace NameOfSpecialSample.Models;

public partial class ContactType
{
    public int ContactTypeIdentifier { get; set; }

    public string ContactTitle { get; set; }

    public virtual ICollection<Contacts> Contacts { get; set; } = new List<Contacts>();

    public virtual ICollection<Customers> Customers { get; set; } = new List<Customers>();

    public virtual ICollection<Employees> Employees { get; set; } = new List<Employees>();
}