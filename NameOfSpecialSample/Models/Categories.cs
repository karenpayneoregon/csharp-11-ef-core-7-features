
#nullable disable


namespace NameOfSpecialSample.Models;

public partial class Categories
{
    /// <summary>
    /// Primary key
    /// </summary>
    public int CategoryID { get; set; }

    /// <summary>
    /// Name of a category
    /// </summary>
    public string CategoryName { get; set; }

    /// <summary>
    /// Description of category
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Image which represents a category
    /// </summary>
    public byte[] Picture { get; set; }

    public virtual ICollection<Products> Products { get; set; } = new List<Products>();
}