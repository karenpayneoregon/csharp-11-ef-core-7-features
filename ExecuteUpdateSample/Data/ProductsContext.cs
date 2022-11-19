using System.Diagnostics;
using ConfigurationLibrary.Classes;
using ExecuteUpdateSample.Models;
using Microsoft.EntityFrameworkCore;

namespace ExecuteUpdateSample.Data;

public class ProductsContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString())
            .EnableSensitiveDataLogging()
            .LogTo(message => Debug.WriteLine(message));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Cheese" },
            new Category { CategoryId = 2, Name = "Meat" },
            new Category { CategoryId = 3, Name = "Fish" },
            new Category { CategoryId = 4, Name = "Bread" });

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, CategoryId = 1, Name = "Cheddar", Price = 10},
            new Product { ProductId = 2, CategoryId = 1, Name = "Brie", Price = 10 },
            new Product { ProductId = 3, CategoryId = 1, Name = "Stilton", Price = 10 },
            new Product { ProductId = 4, CategoryId = 1, Name = "Cheshire", Price = 10 },
            new Product { ProductId = 5, CategoryId = 1, Name = "Swiss", Price = 10 },
            new Product { ProductId = 6, CategoryId = 1, Name = "Gruyere", Price = 10 },
            new Product { ProductId = 7, CategoryId = 1, Name = "Colby", Price = 10 },
            new Product { ProductId = 8, CategoryId = 1, Name = "Mozzela", Price = 10 },
            new Product { ProductId = 9, CategoryId = 1, Name = "Ricotta", Price = 10 },
            new Product { ProductId = 10, CategoryId = 1, Name = "Parmesan", Price = 10 },
            new Product { ProductId = 11, CategoryId = 2, Name = "Ham", Price = 50 },
            new Product { ProductId = 12, CategoryId = 2, Name = "Beef", Price = 60 },
            new Product { ProductId = 13, CategoryId = 2, Name = "Chicken", Price = 70 },
            new Product { ProductId = 14, CategoryId = 2, Name = "Turkey", Price = 10 },
            new Product { ProductId = 15, CategoryId = 2, Name = "Prosciutto", Price = 10 },
            new Product { ProductId = 16, CategoryId = 2, Name = "Bacon", Price = 10 },
            new Product { ProductId = 17, CategoryId = 2, Name = "Mutton", Price = 10 },
            new Product { ProductId = 18, CategoryId = 2, Name = "Pastrami", Price = 10 },
            new Product { ProductId = 19, CategoryId = 2, Name = "Hazlet", Price = 10 },
            new Product { ProductId = 20, CategoryId = 2, Name = "Salami", Price = 10 },
            new Product { ProductId = 21, CategoryId = 3, Name = "Salmon", Price = 10 },
            new Product { ProductId = 22, CategoryId = 3, Name = "Tuna", Price = 10 },
            new Product { ProductId = 23, CategoryId = 3, Name = "Mackerel", Price = 10 },
            new Product { ProductId = 24, CategoryId = 4, Name = "Rye", Price = 10 },
            new Product { ProductId = 25, CategoryId = 4, Name = "Wheat", Price = 10 },
            new Product { ProductId = 26, CategoryId = 4, Name = "Brioche", Price = 10 },
            new Product { ProductId = 27, CategoryId = 4, Name = "Naan", Price = 10 },
            new Product { ProductId = 28, CategoryId = 4, Name = "Focaccia", Price = 10 },
            new Product { ProductId = 29, CategoryId = 4, Name = "Malted", Price = 10 },
            new Product { ProductId = 30, CategoryId = 4, Name = "Sourdough", Price = 10 },
            new Product { ProductId = 31, CategoryId = 4, Name = "Corn", Price = 10 },
            new Product { ProductId = 32, CategoryId = 4, Name = "White", Price = 10 },
            new Product { ProductId = 33, CategoryId = 4, Name = "Soda", Price = 10 });
    }
}
