using PayneServiceLibrary.Classes.Configuration;

namespace WpfHasData.Classes;
internal class MockedData
{

    /// <summary>
    /// Ensures that the database is deleted and recreated if the <see cref="EntitySettings.CreateNew"/> property is set to <c>true</c>.
    /// </summary>
    /// <param name="context">
    /// The <see cref="ProductContext"/> instance representing the database context to operate on.
    /// </param>
    public static void CreateIfNeeded(ProductContext context)
    {
        if (!EntitySettings.Instance.CreateNew) return;
         context.Database.EnsureDeleted();
         context.Database.EnsureCreated();
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
        new() { CategoryId = 1, Name = "Cheese" },
        new() { CategoryId = 2, Name = "Meat" },
        new() { CategoryId = 3, Name = "Fish" },
        new() { CategoryId = 4, Name = "Bread" }
    ];

    /// <summary>
    /// Gets a predefined list of <see cref="Product"/> instances representing mock data
    /// for use in database initialization or testing scenarios.
    /// </summary>
    public static List<Product> Products { get; } =
    [
        new() { ProductId = 1,  CategoryId = 1, Name = "Cheddar" },
        new() { ProductId = 2,  CategoryId = 1, Name = "Brie" },
        new() { ProductId = 3,  CategoryId = 1, Name = "Stilton" },
        new() { ProductId = 4,  CategoryId = 1, Name = "Cheshire" },
        new() { ProductId = 5,  CategoryId = 1, Name = "Swiss" },
        new() { ProductId = 6,  CategoryId = 1, Name = "Gruyere" },
        new() { ProductId = 7,  CategoryId = 1, Name = "Colby" },
        new() { ProductId = 8,  CategoryId = 1, Name = "Mozzela" },
        new() { ProductId = 9,  CategoryId = 1, Name = "Ricotta" },
        new() { ProductId = 10, CategoryId = 1, Name = "Parmesan" },
        new() { ProductId = 11, CategoryId = 2, Name = "Ham" },
        new() { ProductId = 12, CategoryId = 2, Name = "Beef" },
        new() { ProductId = 13, CategoryId = 2, Name = "Chicken" },
        new() { ProductId = 14, CategoryId = 2, Name = "Turkey" },
        new() { ProductId = 15, CategoryId = 2, Name = "Prosciutto" },
        new() { ProductId = 16, CategoryId = 2, Name = "Bacon" },
        new() { ProductId = 17, CategoryId = 2, Name = "Mutton" },
        new() { ProductId = 18, CategoryId = 2, Name = "Pastrami" },
        new() { ProductId = 19, CategoryId = 2, Name = "Hazlet" },
        new() { ProductId = 20, CategoryId = 2, Name = "Salami" },
        new() { ProductId = 21, CategoryId = 3, Name = "Salmon" },
        new() { ProductId = 22, CategoryId = 3, Name = "Tuna" },
        new() { ProductId = 23, CategoryId = 3, Name = "Mackerel" },
        new() { ProductId = 24, CategoryId = 4, Name = "Rye" },
        new() { ProductId = 25, CategoryId = 4, Name = "Wheat" },
        new() { ProductId = 26, CategoryId = 4, Name = "Brioche" },
        new() { ProductId = 27, CategoryId = 4, Name = "Naan" },
        new() { ProductId = 28, CategoryId = 4, Name = "Focaccia" },
        new() { ProductId = 29, CategoryId = 4, Name = "Malted" },
        new() { ProductId = 30, CategoryId = 4, Name = "Sourdough" },
        new() { ProductId = 31, CategoryId = 4, Name = "Corn" },
        new() { ProductId = 32, CategoryId = 4, Name = "White" },
        new() { ProductId = 33, CategoryId = 4, Name = "Soda" }
    ];
}
