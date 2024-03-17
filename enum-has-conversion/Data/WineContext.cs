using System.Diagnostics;
using EnumHasConversion.Classes;
using EnumHasConversion.Models;
using Microsoft.EntityFrameworkCore;
using static ConfigurationLibrary.Classes.ConfigurationHelper;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

#pragma warning disable CS8618

namespace EnumHasConversion.Data;

public class WineContext : DbContext
{
    public DbSet<Wine> Wines { get; set; }
    //public DbSet<WineTypes> WineTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConnectionString())
            .LogTo(message => 
                Debug.WriteLine(message), 
                LogLevel.Information);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Setup conversion to and from int/enum
        modelBuilder
            .Entity<Wine>()
            .Property(e => e.WineType)
            .HasConversion<int>();

        modelBuilder.Entity<WineTypes>().HasData(MockedData.WineTypes());
        modelBuilder.Entity<Wine>().HasData(MockedData.Wines());
    }
}