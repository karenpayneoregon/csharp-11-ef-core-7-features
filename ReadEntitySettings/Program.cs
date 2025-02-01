using Microsoft.EntityFrameworkCore;
using ReadEntitySettings.Classes;
using ReadEntitySettings.Data;

namespace ReadEntitySettings;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await using var context = new Context();
        await MockedData.CreateIfNeeded(context);

        var products = context
            .Products
            .Include(x => x.Category)
            .ToList();

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
}