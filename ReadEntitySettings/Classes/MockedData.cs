using System.Text.Json;
using ReadEntitySettings.Data;
using ReadEntitySettings.Models;

namespace ReadEntitySettings.Classes;
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
        if (!EntitySettings.Instance.GenerateData) return;
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
    public static List<Category> CategoriesFromJson 
        => JsonSerializer.Deserialize<List<Category>>(File.ReadAllText("Categories.json"));

    /// <summary>
    /// Reads and deserializes product data from a JSON file named "Products.json".
    /// </summary>
    /// <returns>
    /// A list of <see cref="Product"/> objects deserialized from the JSON file.
    /// </returns>
    /// <exception cref="FileNotFoundException">
    /// Thrown if the "Products.json" file is not found.
    /// </exception>
    /// <exception cref="JsonException">
    /// Thrown if the JSON content cannot be deserialized into a list of <see cref="Product"/> objects.
    /// </exception>
    /// <remarks>
    /// By using a file a developer can modify the product data without recompiling the application.
    /// </remarks>
    public static List<Product> ProductsFromJson() 
        => JsonSerializer.Deserialize<List<Product>>(File.ReadAllText("Products.json"));
}
