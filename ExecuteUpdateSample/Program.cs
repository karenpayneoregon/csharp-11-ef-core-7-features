using ExecuteUpdateSample.Data;
using Microsoft.EntityFrameworkCore;

namespace ExecuteUpdateSample;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await using var context = new ProductsContext();

        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        var originals = await context.Products
            .Where(p => p.Price > 10).ToListAsync();

        AnsiConsole.MarkupLine("[cyan]Values prior to updated[/]");
        foreach (var product in originals)
        {
            Console.WriteLine($"{product.Name,-12}{product.Price:C}");
        }

        Console.WriteLine();

        /*
         * Update any product where Price is greater than 10, append * to name, subtract 12 from price
         */
        var rows = await context.Products
            .Where(p => p.Price > 10)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Name, p => 
                    p.Name.EndsWith(" *") ? p.Name.Replace(" *", "") : p.Name + " *")
                .SetProperty(p => p.Price, p => p.Price - 12));


        
        if (rows == 3)
        {
            AnsiConsole.MarkupLine("[cyan]Values after updated[/]");
            // NOTE we need to use AsNoTracking as ExecuteUpdateAsync does not track changes
            var updated = context.Products.AsNoTracking().Where(p => p.Name.EndsWith(" *")).ToList();

            foreach (var product in updated)
            {
                Console.WriteLine($"{product.Name,-12}{product.Price:C}");
            }
        }

        Console.WriteLine();
        AnsiConsole.MarkupLine("[cyan]Done[/]");

        Console.ReadLine();
    }
}