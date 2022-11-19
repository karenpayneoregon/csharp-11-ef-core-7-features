using ExecuteDeleteSample.Data;
using Microsoft.EntityFrameworkCore;

namespace ExecuteDeleteSample;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        var table = CreateTableEntityFramework();
        await using var context = new ProductsContext();

        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        var list = await context
            .Products
            .AsNoTracking()
            .ToListAsync();

        table.AddRow("Initial count", list.Count.ToString());
        await context.Products.Where(p => p.CategoryId == 3).ExecuteDeleteAsync();
        table.AddRow("After ExecuteDeleteAsync", context.Products.AsNoTracking().Count().ToString());
        AnsiConsole.Write(table);

        Console.ReadLine();
    }
}