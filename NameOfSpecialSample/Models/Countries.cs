#nullable disable
namespace NameOfSpecialSample.Models;

public partial class Countries
{
    public int CountryIdentifier { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Customers> Customers { get; set; } = new List<Customers>();

    public virtual ICollection<Employees> Employees { get; set; } = new List<Employees>();

    public virtual ICollection<Suppliers> Suppliers { get; set; } = new List<Suppliers>();
}