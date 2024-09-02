using Bogus;

namespace BogusTemp.Classes;

public class MockedData
{
    public static List<Customer> GetCustomersTimeOnlyRandom(int count)
    {
        var identifier = 1;
        Randomizer.Seed = new Random(338);

        var faker = new Faker<Customer>()
            .CustomInstantiator(f => new Customer { Id = identifier++ })
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.Time, f =>
                f.PickRandom(new TimeOnly(9, 0),
                    new TimeOnly(12, 0),
                    new TimeOnly(15, 0)))
            .RuleFor(c => c.Birthdate, f =>
                f.Date.BetweenDateOnly(
                    new DateOnly(1950, 1, 1),
                    new DateOnly(2010, 1, 1)));

        return faker.Generate(count);
    }

    public static List<Customer> GetCustomersDateOnlyTimeOnlyRecent(int count)
    {

        var identifier = 1;
        Randomizer.Seed = new Random(338);

        var faker = new Faker<Customer>()
            .CustomInstantiator(f => new Customer { Id = identifier++ })
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.Time, f => f.Date.RecentTimeOnly())
            .RuleFor(c => c.Birthdate, f => f.Date.RecentDateOnly());

        return faker.Generate(count);

    }

    public static List<Customer> GetCustomersTimeOnlySoon(int count)
    {
        var identifier = 1;
        Randomizer.Seed = new Random(338);

        var faker = new Faker<Customer>()
            .CustomInstantiator(f => new Customer { Id = identifier++ })
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.Time, f => f.Date.SoonTimeOnly())
            .RuleFor(c => c.Birthdate, f =>
                f.Date.BetweenDateOnly(new DateOnly(1950, 1, 1), new DateOnly(2010, 1, 1)));

        return faker.Generate(count);
    }

    public static List<Customer> GetCustomersTimeOnlySoon(int count,DateOnly minDate, DateOnly maxDate)
    {
        var identifier = 1;
        Randomizer.Seed = new Random(338);

        var faker = new Faker<Customer>()
            .CustomInstantiator(f => new Customer { Id = identifier++ })
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.Time, f => f.Date.SoonTimeOnly())
            .RuleFor(c => c.Birthdate, f =>
                f.Date.BetweenDateOnly(minDate, maxDate));

        return faker.Generate(count);
    }

    public static List<Customer> GetCustomersTimeOnlyRecent(int count)
    {
        var identifier = 1;
        Randomizer.Seed = new Random(338);

        var faker = new Faker<Customer>()
            .CustomInstantiator(f => new Customer { Id = identifier++ })
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.Time, f => f.Date.RecentTimeOnly())
            .RuleFor(c => c.Birthdate, f =>
                f.Date.BetweenDateOnly(
                    new DateOnly(1950, 1, 1),
                    new DateOnly(2010, 1, 1)));

        return faker.Generate(count);
    }
}