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

    /// <summary>
    /// Configures the model for the database context by applying entity configurations
    /// and seeding initial data if the <see cref="EntitySettings.GenerateData"/> property is set to <c>true</c>.
    /// </summary>
    /// <param name="modelBuilder">
    /// An instance of <see cref="ModelBuilder"/> used to configure entity mappings and relationships.
    /// </param>
    /// <remarks>
    /// This method seeds the database with predefined categories and products by utilizing 
    /// data from <see cref="MockedData.CategoriesFromJson"/> and <see cref="MockedData.ProductsFromJson"/>.
    /// </remarks>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        if (!EntitySettings.Instance.GenerateData) return;

        modelBuilder.Entity<Category>().HasData(MockedData.CategoriesFromJson);
        modelBuilder.Entity<Product>().HasData(MockedData.ProductsFromJson);

    }
}
