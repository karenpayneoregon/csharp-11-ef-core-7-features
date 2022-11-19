using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TableSplittingSample.Classes;

public static class ModelBuildingSample
{
    public static async Task Entity_splitting()
    {
        PrintSampleName();

        await using (var context = new EntitySplittingContext())
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            await context.AddRangeAsync(
                new Customer("Alice", "1 Main St", "Chigley", "CW1 5ZH", "UK") { PhoneNumber = "01632 12348" },
                new Customer("Mac", "2 Main St", "Chigley", "CW1 5ZH", "UK"),
                new Customer("Toast", "3 Main St", "Chigley", null, "UK") { PhoneNumber = "01632 12348" });

            await context.SaveChangesAsync();
        }

        await using (var context = new EntitySplittingContext())
        {
            var customers = await context.Customers
                .Where(customer => customer.PhoneNumber!.StartsWith("01632") && customer.City == "Chigley")
                .OrderBy(customer => customer.PostCode)
                .ThenBy(customer => customer.Name)
                .ToListAsync();

            Console.WriteLine();

            foreach (var customer in customers)
            {
                AnsiConsole.MarkupLine($"[cyan]{customer.Name}[/] from [cyan]{customer.City}[/] with phone [cyan]{customer.PhoneNumber}[/]");
            }
        }
    }


    private static void PrintSampleName([CallerMemberName] string? methodName = null)
    {
        AnsiConsole.MarkupLine($"[yellow]>>>> Sample: {methodName}[/]");
        Console.WriteLine();
    }





    #region Animals
    public abstract class Animal
    {
        public int Id { get; set; }
        public string Breed { get; set; } = null!;
    }

    public class Cat : Animal
    {
        public string? EducationalLevel { get; set; }
    }

    public class Dog : Animal
    {
        public string? FavoriteToy { get; set; }
    }
    #endregion

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

    #region CombinedCustomer
    public class Customer
    {
        public Customer(string name, string street, string city, string? postCode, string country)
        {
            Name = name;
            Street = street;
            City = city;
            PostCode = postCode;
            Country = country;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string? PostCode { get; set; }
        public string Country { get; set; }
    }
    #endregion

    #region EmployeeAndEmployeeInfo
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; } = null!;

        public EmployeeInfo Info { get; set; } = null!;
    }

    public class EmployeeInfo
    {
        public string Position { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string? Address { get; set; }
        public decimal? AnnualSalary { get; set; }
    }
    #endregion
}
