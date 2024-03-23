using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using TableSplittingSample.Data;
using TableSplittingSample.Models;

namespace TableSplittingSample.Classes;

public static class ModelBuildingSample
{
    public static async Task Entity_splitting()
    {
        PrintSampleName();

        await using (var context = new EntitySplittingContext())
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            await context.AddRangeAsync(
                new Customer("Alice", "1 Main St", "Chigley", "CW1 5ZH", "UK") { PhoneNumber = "01632 12348" },
                new Customer("Mac", "2 Main St", "Chigley", "CW1 5ZH", "UK"),
                new Customer("Toast", "3 Main St", "Chigley", null, "UK") { PhoneNumber = "01632 12348" });

            await context.SaveChangesAsync();
        }

        await using (var context = new EntitySplittingContext())
        {
            var customers = await context.Customers
                .Where(customer => customer.PhoneNumber!.StartsWith("01632") && customer.City == "Chigley")
                .OrderBy(customer => customer.PostCode)
                .ThenBy(customer => customer.Name)
                .ToListAsync();

            Console.WriteLine();

            foreach (var customer in customers)
            {
                AnsiConsole.MarkupLine($"[cyan]{customer.Name}[/] from " +
                                       $"[cyan]{customer.City}[/] with phone " +
                                       $"[cyan]{customer.PhoneNumber}[/]");
            }
        }
    }


    private static void PrintSampleName([CallerMemberName] string? methodName = null)
    {
        AnsiConsole.MarkupLine($"[yellow]>>>> Sample: {methodName}[/]");
        Console.WriteLine();
    }
    

}
