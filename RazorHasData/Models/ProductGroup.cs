namespace RazorHasData.Models;
/// <summary>
/// Represents a group of products categorized under a specific category.
/// </summary>
/// <remarks>
/// This class is used to group products by their associated category, providing
/// an organized structure for handling and displaying categorized product data.
/// </remarks>
public class ProductGroup
{
    public Category Category { get; }
    public List<Product> Products { get; }

    public ProductGroup(Category category, List<Product> products)
    {
        Category = category;
        Products = products;
    }
}