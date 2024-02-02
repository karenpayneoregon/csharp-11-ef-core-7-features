using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using Guard = Ardalis.GuardClauses.Guard;

namespace DiagnosticsGuardSampleApp;
/*
 * For working with https://github.com/ardalis/GuardClauses/tree/main
 */
internal class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; }
    public int CategoryID { get; set; }
    public decimal? UnitPrice { get; set; }
    public DateOnly DiscontinuedDate { get; set; }

    // The navigation property
    public Category Category { get; set; }

    public Product(string productName, int categoryId, decimal unitPrice, DateOnly discontinuedDate)
    {
        
        ProductName = Guard.Against.NullOrWhiteSpace(productName);
        CategoryID = Guard.Against.OutOfRange(categoryId,categoryId.ToString(),1,7);
        UnitPrice = Guard.Against.Negative(unitPrice);
        DiscontinuedDate = Guard.Against.OutOfRange(discontinuedDate, discontinuedDate.ToString(), new DateOnly(2024, 1, 1), new DateOnly(2024,1,12));
    }
    public Product(string productName, Category category, decimal unitPrice, DateOnly discontinuedDate)
    {

        ProductName = Guard.Against.NullOrWhiteSpace(productName);
        Category = Guard.Against.Null(category);
        UnitPrice = unitPrice;
        DiscontinuedDate = discontinuedDate;
    }

}

public class Category : IEquatable<Category>
{
    [Key]
    public int CategoryID { get; set; }

    public string CategoryName { get; set; }
    public bool Equals(Category other) => CategoryID == other?.CategoryID;
    public override string ToString() => CategoryName;
}
