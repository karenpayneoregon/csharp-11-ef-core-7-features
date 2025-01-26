using Bogus;
using Bogus.DataSets;
using BogusProperGenderEntityApp.Models;
// ReSharper disable MethodOverloadWithOptionalParameter

namespace BogusProperGenderEntityApp.Classes;

public class BogusOperations
{
    public static List<GenderData> GenderTypes() =>
    [
        new() { Id = 1, Name = "Male" }, new() { Id = 2, Name = "Female"}
    ];

    /// <summary>
    /// Generates a list of people with random data.
    /// </summary>
    /// <param name="count">The number of people to generate.</param>
    /// <param name="identifier">An optional identifier to initialize the <see cref="BirthDays"/> objects. Default is 1.</param>
    /// <returns>A list of <see cref="BirthDays"/> objects with randomly generated data.</returns>
    public static List<BirthDays> PeopleList(int count, int identifier = 1)
    {
        //var identifier = 1;
        Randomizer.Seed = new Random(338);

        var faker = new Faker<BirthDays>()
            .CustomInstantiator(f => new BirthDays(identifier++))
            .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
            .RuleFor(c => c.FirstName, (f, c) => f.Name.FirstName((Name.Gender?)c.Gender))
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.BirthDate, f => f.Date.BetweenDateOnly(new DateOnly(1950, 1, 1), new DateOnly(2010, 1, 1)))
            .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName));

        return faker.Generate(count);
    }

    /// <summary>
    /// Generates a consistent list of people with repeatable random data.
    /// </summary>
    /// <param name="count">The number of people to generate.</param>
    /// <param name="seed">The seed value for generating repeatable data. Default is 338.</param>
    /// <param name="identifier">
    /// An optional identifier to initialize the <see cref="BirthDays"/> objects. 
    /// This value is incremented for each generated person. Default is 1.
    /// </param>
    /// <returns>
    /// A list of <see cref="BirthDays"/> objects with consistent and repeatable random data.
    /// </returns>
    public static List<BirthDays> PeopleList(int count, int seed = 338, int identifier = 1)
    {
        Randomizer.Seed = new Random(seed);

        var faker = new Faker<BirthDays>().Rules((f, b) =>
        {
            b.Id = identifier++;
            b.Gender = f.PickRandom<Gender>();
            b.FirstName = f.Name.FirstName((Name.Gender?)b.Gender);
            b.LastName = f.Name.LastName();
            b.BirthDate = f.Date.BetweenDateOnly(new DateOnly(1950, 1, 1), new DateOnly(2010, 1, 1));
            b.Email = f.Internet.Email(b.FirstName, b.LastName);

        });

        return faker.Generate(count);
    }
}

