#nullable disable

namespace NameOfSpecialSample.Models;

public partial class SupplierRegion
{
    public int RegionId { get; set; }

    public string RegionDescription { get; set; }

    public virtual ICollection<Suppliers> Suppliers { get; set; } = new List<Suppliers>();
}