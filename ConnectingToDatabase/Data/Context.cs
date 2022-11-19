using System.Diagnostics;
using ConfigurationLibrary.Classes;
using ConnectingToDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectingToDatabase.Data;

public class Context : DbContext
{
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString())
            .EnableSensitiveDataLogging()
            .LogTo(message => Debug.WriteLine(message));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Cheese" }, new Category { CategoryId = 2, Name = "Meat" });

    }
}
