namespace ReadEntitySettings.Models;

/// <summary>
/// Represents a product entity in the application, which is associated with a category.
/// This class is used to model product data for storage and retrieval in a database.
/// </summary>
public class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; }

    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
    public override string ToString() => Name;
}
