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
    /// Gets a list of <see cref="Category"/> objects deserialized from the "Categories.json" file.
    /// </summary>
    /// <remarks>
    /// This property reads the content of the "Categories.json" file and deserializes it into a list of 
    /// <see cref="Category"/> instances using the <see cref="System.Text.Json.JsonSerializer"/>.
    /// Ensure that the "Categories.json" file exists and contains valid JSON data before accessing this property.
    /// </remarks>
    /// <returns>
    /// A list of <see cref="Category"/> objects representing the categories defined in the JSON file.
    /// </returns>
    /// <exception cref="System.IO.FileNotFoundException">
    /// Thrown if the "Categories.json" file is not found.
    /// </exception>
    /// <exception cref="System.Text.Json.JsonException">
    /// Thrown if the JSON content of the file cannot be deserialized into a list of <see cref="Category"/> objects.
    /// </exception>
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
    public static List<Product> ProductsFromJson 
        => JsonSerializer.Deserialize<List<Product>>(File.ReadAllText("Products.json"));
}
