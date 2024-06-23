using Bogus;

namespace BogusTemp;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]Hello[/]");
        Console.ReadLine();
    }
}
public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthdate { get; set; }
}

public class MockedData
{
    public static List<Customer> GetCustomers(int count)
    {
        var identifier = 1;
        Randomizer.Seed = new Random(338);

        var faker = new Faker<Customer>()
            .CustomInstantiator(f => new Customer { Id = identifier++ })
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.Birthdate, f => 
                f.Date.BetweenDateOnly(new DateOnly(1950, 1, 1), new DateOnly(2010, 1, 1)));

        return faker.Generate(count);
    }
}