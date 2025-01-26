namespace SqliteHasData.Models;

/// <summary>
/// Represents a category entity in the application, which is associated with a collection of products.
/// This class is used to model category data for storage and retrieval in a database.
/// </summary>
public class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; }

    public virtual List<Product> Products { get; } = [];
    public override string ToString() => Name;

}
