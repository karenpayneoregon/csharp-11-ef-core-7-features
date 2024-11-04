#nullable disable
using StringTokenFormatter;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace StringSyntaxAttributeExampleApp.Classes;
public class Operations
{
    public static void SetDateFormat([StringSyntax(StringSyntaxAttribute.DateTimeFormat)] string format, params object[] arguments)
    {
   

    }

    public static void FormatRex([StringSyntax(StringSyntaxAttribute.Regex)] string regex)
    {
        
    }

    public static void SetNumberFormat([StringSyntax(StringSyntaxAttribute.NumericFormat)] string sender)
    {
        
    }

    public static FormattableString CompositeFormat(Customer customer, [StringSyntax(StringSyntaxAttribute.CompositeFormat)] string sender) 
        => FormattableStringFactory.Create(sender, customer.FirstName, customer.LastName, customer.Age, "S");


    /// <summary>
    /// Demonstrates the usage of the Operations class.
    /// </summary>
    public static void Demo()
    {
        // Create a new Customer object
        Customer customer = new() {
            FirstName = "Karen",
            LastName = "Payne",
            Title = "Ms",
            IsFirstOrder = false,
        };

        // Create a dynamic order object
        var order = new
        {
            Id = GetRandomNumber(),
        };

        var orderLines = new[]
        {
            new OrderLine(product: "T-shirt", price: 25.5),
            new OrderLine(product: "Coat", price: 40.0),
            new OrderLine(product: "Socks", price: 14.0),
        };

        // Define the mail template for an order
        string mailTemplate =
            """
            Hello {Customer.Title} {Customer.FirstName} {Customer.LastName},
            
            Thank you for {:map,Customer.IsFirstOrder:true=your first order,false=your order}.
            
            Items in Order Number: {Order.Id}
            {:loop,OrderLines}
               {OrderLines.Product} @ {OrderLines.Price:C}
            {:loopend}
            Total: {OrderTotal:C}
            Ref: {MessageId:Initial} 
            """;

        // Create an instance of the InterpolatedStringResolver
        var resolver = new InterpolatedStringResolver(Settings);

        // Interpolate the mail template
        var interpolatedString = resolver.Interpolate(mailTemplate);

        // Build the combined container with the necessary data
        var combinedContainer = resolver.Builder()
            .AddPrefixedObject("Customer", customer)
            .AddPrefixedObject("Order", order)
            .AddSequence("OrderLines", orderLines)
            .AddSingle("OrderTotal", orderLines.Sum(x => x.Price))
            .AddSingle("MessageId", new Lazy<object>(() => Guid.Parse("73054fad-ba31-4cc2-a1c1-ac534adc9b45")))
            .CombinedResult();

        // Resolve the interpolated string using the combined container
        string actual = resolver.FromContainer(interpolatedString, combinedContainer);

        // Output the result
        Debug.WriteLine(actual);
    }

    // Configure the StringTokenFormatter settings
    private static StringTokenFormatterSettings Settings => new()
    {
        FormatProvider = CultureInfo.GetCultureInfo("en-US"),
        FormatterDefinitions = [
            FormatterDefinition.ForTokenName<int>("Order.Id", OrderIdFormatter),
            FormatterDefinition.ForType<Guid>(GuidFormatter),
        ],
    };

    // Define a custom formatter for order IDs
    private static string OrderIdFormatter(int id, string format) 
        => $"#{id:000000}";

    // Define a custom formatter for Guids
    private static string GuidFormatter(Guid guid, string format) => 
        format == $"Initial" ? guid.ToString("D").Split('-')[0].ToUpper() : guid.ToString();

    public static int GetRandomNumber()
    {
        Random random = new();
        return random.Next(100, 201);
    }


}

public class Customer
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public bool IsFirstOrder { get; set; }
}
public class OrderLine
{
    public OrderLine(string product, double price)
    {
        Product = product;
        Price = price;
    }
    public string Product { get; }
    public double Price { get; }
}