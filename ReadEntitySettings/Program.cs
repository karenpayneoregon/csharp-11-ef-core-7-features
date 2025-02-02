using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using ReadEntitySettings.Classes;
using ReadEntitySettings.Data;
using ReadEntitySettings.Models;

namespace ReadEntitySettings;

internal partial class Program
{
    private static async Task Main(string[] args)
    {
        await using var context = new Context();
        await MockedData.CreateIfNeeded(context);

        var products = context
            .Products
            .Include(x => x.Category)
            .ToList();

 
        /*
         * Groups the products by their category.
         */
        var groupedProducts = products
            .GroupBy(p => p.Category)
            .Select(group => new
            {
                Category = group.Key,
                Products = group.OrderBy(x => x.Name).ToList()
            })
            .OrderBy(x => x.Category.Name);

        foreach (var group in groupedProducts)
        {
            AnsiConsole.MarkupLine($"[cyan]{group.Category.Name}[/]");
            foreach (var product in group.Products)
            {
                Console.WriteLine($"     {product.Name}");
            }
        }

        
        Console.ReadLine();

    }

    /// <summary>
    /// Writes the list of products from the specified database context to a JSON file.
    /// </summary>
    /// <param name="context">
    /// The database context containing the products to be written to the file.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation of writing the products to the file.
    /// </returns>
    /// <remarks>
    /// Categories are not written to the file, only the products.
    /// </remarks>
    private static async Task WriteProductsToFile(Context context)
    {
        List<Product> list = context.Products.ToList();
        await File.WriteAllTextAsync("Products.json", JsonSerializer.Serialize(
            list, JsonSerializerOptions));
    }

    private static async Task WriteCategoriesToFile(Context context)
    {
        List<Category> list = context.Categories.ToList();
        await File.WriteAllTextAsync("Categories.json", JsonSerializer.Serialize(
            list, JsonSerializerOptions));
    }
    /// <summary>
    /// Gets the JSON serializer options used for serializing objects to JSON.
    /// </summary>
    /// <value>
    /// The <see cref="JsonSerializerOptions"/> instance configured with specific settings,
    /// such as enabling indented formatting for better readability.
    /// </value>
    /// <remarks>
    /// This property is used to configure the serialization behavior when writing objects to JSON files.
    /// </remarks>
    private static JsonSerializerOptions JsonSerializerOptions =>
        new()
        {
            WriteIndented = true
        };
}