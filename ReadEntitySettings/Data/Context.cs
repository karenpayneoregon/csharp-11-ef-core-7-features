using Microsoft.EntityFrameworkCore;
using ReadEntitySettings.Classes;
using ReadEntitySettings.Models;

namespace ReadEntitySettings.Data;

public class Context : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=products.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        if (!EntitySettings.Instance.GenerateData) return;

        modelBuilder.Entity<Category>().HasData(MockedData.Categories);
        modelBuilder.Entity<Product>().HasData(MockedData.ProductsFromJson());

    }
}
