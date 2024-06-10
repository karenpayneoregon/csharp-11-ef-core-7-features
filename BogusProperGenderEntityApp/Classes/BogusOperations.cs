using Bogus;
using Bogus.DataSets;
using BogusProperGenderEntityApp.Models;

namespace BogusProperGenderEntityApp.Classes;

public class BogusOperations
{
    public static List<GenderData> GenderTypes() =>
    [
        new() { Id = 1, Name = "Male" },
        new() { Id = 2, Name = "Female"}
    ];

    public static List<BirthDays> CustomersList(int count)
    {

        int identifier = 1;

        Randomizer.Seed = new Random(338);

        var faker = new Faker<BirthDays>()
            .CustomInstantiator(f => new BirthDays(identifier++))
            .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
            .RuleFor(c => c.FirstName, (f, c) => f.Name.FirstName((Name.Gender?)c.Gender))
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.BirthDate, f => f.Date.BetweenDateOnly(new DateOnly(1950, 1, 1), new DateOnly(2010, 1, 1)))
            .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName));

        var list = faker.Generate(count);

        return list;

    }
}