#nullable disable
namespace NameOfSpecialSample.Models;

public partial class Shippers
{
    public int ShipperID { get; set; }

    public string CompanyName { get; set; }

    public string Phone { get; set; }

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
}