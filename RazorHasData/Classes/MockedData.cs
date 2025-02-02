using PayneServiceLibrary.Classes.Configuration;
using RazorHasData.Data;
using RazorHasData.Models;

namespace RazorHasData.Classes;
internal class MockedData
{
    /// <summary>
    /// Ensures that the database is properly initialized by deleting and recreating it
    /// if the <see cref="EntitySettings.CreateNew"/> property is set to <c>true</c>.
    /// </summary>
    /// <param name="context">
    /// The <see cref="Context"/> instance representing the database context.
    /// </param>
    public static async Task CreateIfNeeded(Context context)
    {
        if (!EntitySettings.Instance.CreateNew) return;
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
    }
    /// <summary>
    /// Gets the predefined list of <see cref="Category"/> objects used to seed the database.
    /// </summary>
    /// <remarks>
    /// This property provides a static collection of categories, each with a unique identifier and name.
    /// It is utilized during the database initialization process to populate the <c>Categories</c> table.
    /// </remarks>
    public static List<Category> Categories { get; } =
    [
        new Category { CategoryId = 1, Name = "Cheese" },
        new Category { CategoryId = 2, Name = "Meat" },
        new Category { CategoryId = 3, Name = "Fish" },
        new Category { CategoryId = 4, Name = "Bread" }
    ];

    /// <summary>
    /// Gets a predefined list of <see cref="Product"/> instances representing mock data
    /// for use in database initialization or testing scenarios.
    /// </summary>
    public static List<Product> Products { get; } =
    [
        new Product { ProductId = 1, CategoryId = 1, Name = "Cheddar" },
        new Product { ProductId = 2, CategoryId = 1, Name = "Brie" },
        new Product { ProductId = 3, CategoryId = 1, Name = "Stilton" },
        new Product { ProductId = 4, CategoryId = 1, Name = "Cheshire" },
        new Product { ProductId = 5, CategoryId = 1, Name = "Swiss" },
        new Product { ProductId = 6, CategoryId = 1, Name = "Gruyere" },
        new Product { ProductId = 7, CategoryId = 1, Name = "Colby" },
        new Product { ProductId = 8, CategoryId = 1, Name = "Mozzela" },
        new Product { ProductId = 9, CategoryId = 1, Name = "Ricotta" },
        new Product { ProductId = 10, CategoryId = 1, Name = "Parmesan" },
        new Product { ProductId = 11, CategoryId = 2, Name = "Ham" },
        new Product { ProductId = 12, CategoryId = 2, Name = "Beef" },
        new Product { ProductId = 13, CategoryId = 2, Name = "Chicken" },
        new Product { ProductId = 14, CategoryId = 2, Name = "Turkey" },
        new Product { ProductId = 15, CategoryId = 2, Name = "Prosciutto" },
        new Product { ProductId = 16, CategoryId = 2, Name = "Bacon" },
        new Product { ProductId = 17, CategoryId = 2, Name = "Mutton" },
        new Product { ProductId = 18, CategoryId = 2, Name = "Pastrami" },
        new Product { ProductId = 19, CategoryId = 2, Name = "Hazlet" },
        new Product { ProductId = 20, CategoryId = 2, Name = "Salami" },
        new Product { ProductId = 21, CategoryId = 3, Name = "Salmon" },
        new Product { ProductId = 22, CategoryId = 3, Name = "Tuna" },
        new Product { ProductId = 23, CategoryId = 3, Name = "Mackerel" },
        new Product { ProductId = 24, CategoryId = 4, Name = "Rye" },
        new Product { ProductId = 25, CategoryId = 4, Name = "Wheat" },
        new Product { ProductId = 26, CategoryId = 4, Name = "Brioche" },
        new Product { ProductId = 27, CategoryId = 4, Name = "Naan" },
        new Product { ProductId = 28, CategoryId = 4, Name = "Focaccia" },
        new Product { ProductId = 29, CategoryId = 4, Name = "Malted" },
        new Product { ProductId = 30, CategoryId = 4, Name = "Sourdough" },
        new Product { ProductId = 31, CategoryId = 4, Name = "Corn" },
        new Product { ProductId = 32, CategoryId = 4, Name = "White" },
        new Product { ProductId = 33, CategoryId = 4, Name = "Soda" }
    ];
}
