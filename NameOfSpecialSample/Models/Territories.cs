#nullable disable
namespace NameOfSpecialSample.Models;

public partial class Territories
{
    public string TerritoryID { get; set; }

    public string TerritoryDescription { get; set; }

    public int RegionID { get; set; }

    public virtual Region Region { get; set; }

    public virtual ICollection<Employees> Employee { get; set; } = new List<Employees>();
}