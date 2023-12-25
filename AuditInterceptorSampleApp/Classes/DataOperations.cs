using AuditInterceptorSampleApp.Data;
using AuditInterceptorSampleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AuditInterceptorSampleApp.Classes;

internal class DataOperations
{
    /// <summary>
    /// Used to create the database only if it does not exist
    /// Does not populate <see cref="Category"/> table
    /// </summary>
    /// <returns></returns>
    public static async Task<(bool success, Exception exception)> InitialCreateDatabase()
    {
        try
        {
            await using var context = new BookContext();

            var (success, _) = await context.CanConnectAsync();
            if (success) return (true, null);
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            return (true, null);
        }
        catch (Exception localException)
        {

            return (false, localException);
        }
    }

    public static async Task<List<Book>> ReadBack()
    {
        await using var context = new BookContext();
        return context.Books.Include(x => x.Category).ToList();
    }

    /// <summary>
    /// Used to start over with some <see cref="Category"/> rows
    /// </summary>
    public static async Task<(bool success, Exception exception)> CreateDatabaseAndPopulate()
    {
        try
        {
            await using var context = new BookContext();
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();


            context.Categories.Add(new Category() { Description = "Learn C#" });
            context.Categories.Add(new Category() { Description = "EF Core 7" });

            await context.SaveChangesAsync();

            context.Books.Add(new Book()
            {
                Price = 44.99m,
                Title = "C# in Depth",
                CategoryId = 1
            });

            context.Books.Add(new Book()
            {
                Price = 31.99m,
                Title = "C# 11 and .NET 7 – Modern Cross-Platform Development Fundamentals: Start building websites and services with ASP.NET Core 7, Blazor, and EF Core 7",
                CategoryId = 1
            });

            context.Books.Add(new Book()
            {
                Price = 43.99m,
                Title = "Apps and Services with .NET 7: Build practical projects with Blazor, .NET MAUI, gRPC, GraphQL, and other enterprise technologies",
                CategoryId = 1
            });

            context.Books.Add(new Book()
            {
                Price = 55.99m,
                Title = "Entity Framework Core in Action",
                CategoryId = 2
            });


            context.Books.Add(new Book()
            {
                Price = 45.99m,
                Title = "Practical Entity Framework Core 6 : Database Access for Enterprise Applications",
                CategoryId = 2
            });

            await context.SaveChangesAsync();

            return (true, null);

        }
        catch (Exception localException)
        {
            return (false, localException);
        }
    }

    public static async Task UpdateRecords()
    {
        await using var context = new BookContext();

        int identifier = 1;
        var book = await context.Books.FirstOrDefaultAsync(x => x.Id == identifier);
        book.Title = "C# in Depth - changed";
        book.Price += 10;


        identifier = 4;
        book = await context.Books.FirstOrDefaultAsync(x => x.Id == identifier);
        book.Title = "Entity Framework Core in Action - updated";
        book.Price -= 10;

        await context.SaveChangesAsync();
    }
}