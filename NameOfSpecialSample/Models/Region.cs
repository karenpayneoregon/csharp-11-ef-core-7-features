#nullable disable

namespace NameOfSpecialSample.Models;

public partial class Region
{
    public int RegionID { get; set; }

    public string RegionDescription { get; set; }

    public virtual ICollection<Territories> Territories { get; set; } = new List<Territories>();
}