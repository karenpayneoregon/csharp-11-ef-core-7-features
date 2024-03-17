using ComplexTypesSampleApp.Data;
using ComplexTypesSampleApp.Models;

namespace ComplexTypesSampleApp.Classes;
internal class Operations
{
    public static async Task ComplexTypesDemo()
    {
        PrintCyan();

        await using var context = new Context();
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();


        var customer = new Customer
        {
            Name = "Centro comercial Moctezuma",
            Address = new()
            {
                Line1 = "Sierras de Granada 9993", 
                Line2 = "Suite 100",
                City = "Buenos Aires", 
                Country = "Argentina", 
                PostCode = "05022"
            }
        };

        context.Add(customer);
        await context.SaveChangesAsync();

        customer.Orders.Add(
            new Order
            {
                Contents = "Tesco Tasty Treats", 
                BillingAddress = customer.Address, 
                ShippingAddress = customer.Address,
            });

        await context.SaveChangesAsync();

        customer.Address.Line1 = "Forsterstr. 57";
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();

    }
}

