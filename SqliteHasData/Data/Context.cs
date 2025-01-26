using Microsoft.EntityFrameworkCore;
using PayneServiceLibrary.Classes.Configuration;
using SqliteHasData.Classes;
using SqliteHasData.Models;


namespace SqliteHasData.Data;

public class Context : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite(DataConnections.Instance.MainConnection);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        if (!EntitySettings.Instance.CreateNew) return;

        modelBuilder.Entity<Category>().HasData(MockedData.Categories);
        modelBuilder.Entity<Product>().HasData(MockedData.Products);

    }
}
