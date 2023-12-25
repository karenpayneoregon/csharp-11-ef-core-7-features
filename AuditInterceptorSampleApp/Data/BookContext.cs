using System.Diagnostics;
using AuditInterceptorSampleApp.Classes;
using AuditInterceptorSampleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Serilog;
using static ConfigurationLibrary.Classes.ConfigurationHelper;

namespace AuditInterceptorSampleApp.Data;

public class BookContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        StandardLogging(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

    /// <summary>
    /// Setup connection for no logging and no change tracking
    /// </summary>
    public static void NoLogging(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder
            .UseSqlServer(ConnectionString())
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

    }

    /// <summary>
    /// Setup connection
    /// Log to a log file via SeriLog
    /// </summary>
    public static void StandardLogging(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder
            .UseSqlServer(ConnectionString())
            .EnableSensitiveDataLogging()
            .AddInterceptors(new AuditInterceptor())
            .LogTo(message => Debug.WriteLine(message));

    }

    /// <summary>
    /// Setup connection
    /// Slimmed down to specific details
    /// </summary>
    private static void DatabaseCategoryLogging(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder
            .UseSqlServer(ConnectionString())
            .EnableSensitiveDataLogging()
            .LogTo(message => Debug.WriteLine(message),
                new[] { DbLoggerCategory.Database.Command.Name },
                LogLevel.Information,
                DbContextLoggerOptions.UtcTime);

    }

    /// <summary>
    /// Setup connection
    /// Writes/appends to a file
    /// </summary>
    private static void CustomLogging(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder
            .UseSqlServer(ConnectionString())
            .EnableSensitiveDataLogging()
            //.LogTo(new DbContextToFileLogger().Log)
            .EnableDetailedErrors();

    }

    private static void SeriLogging(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder
            .UseSqlServer(ConnectionString())
            .EnableSensitiveDataLogging()
            .LogTo(Log.Logger.Information, LogLevel.Information, null)
            .EnableDetailedErrors();

    }
}