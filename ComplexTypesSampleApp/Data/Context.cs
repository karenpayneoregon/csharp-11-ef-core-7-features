using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplexTypesSampleApp.Classes;
using ComplexTypesSampleApp.Models;

namespace ComplexTypesSampleApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
internal class Context : DbContext
{
    public Context()
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder
            .UseSqlServer(DataConnections.Instance.MainConnection)
            .EnableSensitiveDataLogging()
            .LogTo(new DbContextToFileLogger().Log,
                new[]
                {
                    DbLoggerCategory.Database.Command.Name
                },
                LogLevel.Information);
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .ComplexProperty(e => e.Address);

        modelBuilder.Entity<Order>(b =>
        {
            b.ComplexProperty(e => e.BillingAddress);
            b.ComplexProperty(e => e.ShippingAddress);
        });
    }
}
