using EntityCoreFileLogger;
using KP_WindowsFormsNET9.EFCore.Sample1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KP_WindowsFormsNET9.EFCore.Sample1.Data;

/// <summary>
/// Represents the database context for customer-related operations, 
/// providing access to customer data and configurations for Entity Framework Core.
/// </summary>
/// <param name="useSqlite">Indicates whether to use SQLite as the database provider.</param>
/// <remarks>
/// Log SQL commands to a file using Karen Payne NuGet package EntityCoreFileLogger. See MakeLogDir in the project file.
/// </remarks>
public class CustomerContext(bool useSqlite = false) : DbContext
{
    public bool UseSqlite { get; } = useSqlite;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => (UseSqlite
                ? optionsBuilder.UseSqlite(@$"DataSource={GetType().Name}.db",
                    sqliteOptionsBuilder => sqliteOptionsBuilder.UseNetTopologySuite())
                : optionsBuilder.UseSqlServer(
                    @$"Server=(localdb)\mssqllocaldb;Database={GetType().Name};ConnectRetryCount=0",
                    sqlServerOptionsBuilder => sqlServerOptionsBuilder.UseNetTopologySuite()))
            .EnableSensitiveDataLogging()
            .LogTo(new DbContextToFileLogger().Log, [DbLoggerCategory.Database.Command.Name],
                LogLevel.Information);

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.ComplexProperties<CustomerInfo>();
    }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<CustomerWithStores> CustomersWithStores => Set<CustomerWithStores>();
    public DbSet<Store> Stores => Set<Store>();
    public DbSet<CustomerTpt> TptCustomers => Set<CustomerTpt>();
    public DbSet<SpecialCustomerTpt> TptSpecialCustomers => Set<SpecialCustomerTpt>();
}