    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TableSplittingSample.Models;

namespace TableSplittingSample.Data;
public class EntitySplittingContext : DbContext
{
    public DbSet<Customer> Customers
        => Set<Customer>();

    public DbSet<Employee> Employees
        => Set<Employee>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSqlServer(@$"Server=(localdb)\mssqllocaldb;Database=Images")
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region EntitySplitting
        modelBuilder.Entity<Customer>(
            entityBuilder =>
            {
                entityBuilder
                    .ToTable("Customers")
                    .SplitToTable(
                        "PhoneNumbers",
                        tableBuilder =>
                        {
                            tableBuilder.Property(customer => customer.Id).HasColumnName("CustomerId");
                            tableBuilder.Property(customer => customer.PhoneNumber);
                        })
                    .SplitToTable(
                        "Addresses",
                        tableBuilder =>
                        {
                            tableBuilder.Property(customer => customer.Id).HasColumnName("CustomerId");
                            tableBuilder.Property(customer => customer.Street);
                            tableBuilder.Property(customer => customer.City);
                            tableBuilder.Property(customer => customer.PostCode);
                            tableBuilder.Property(customer => customer.Country);
                        });
            });
        #endregion

        #region LinkingForeignKey
        modelBuilder.Entity<Customer>()
            .HasOne<Customer>()
            .WithOne()
            .HasForeignKey<Customer>(a => a.Id)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion

        #region OwnedTemporalTable
        modelBuilder
            .Entity<Employee>()
            .ToTable(
                "Employees",
                tableBuilder =>
                {
                    tableBuilder.IsTemporal();
                    tableBuilder.Property<DateTime>("PeriodStart").HasColumnName("PeriodStart");
                    tableBuilder.Property<DateTime>("PeriodEnd").HasColumnName("PeriodEnd");
                })
            .OwnsOne(
                employee => employee.Info,
                ownedBuilder => ownedBuilder.ToTable(
                    "Employees",
                    tableBuilder =>
                    {
                        tableBuilder.IsTemporal();
                        tableBuilder.Property<DateTime>("PeriodStart").HasColumnName("PeriodStart");
                        tableBuilder.Property<DateTime>("PeriodEnd").HasColumnName("PeriodEnd");
                    }));
        #endregion
    }
}