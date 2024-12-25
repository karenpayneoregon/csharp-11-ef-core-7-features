using Bogus;
using static Bogus.Randomizer;
using Bogus.DataSets;
using NewStuffApp.Models;
using Person = NewStuffApp.Models.Person;

namespace NewStuffApp.Classes;
internal class BogusOperations
{
    public static List<Person> PersonsList(int count, bool random = false)
    {
        if (!random)
        {
            Seed = new Random(338);
        }

        var id = 1;

        var faker = new Faker<Person>()
            .RuleFor(c => c.Id, f => id++)
            .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
            .RuleFor(c => c.FirstName, (f, u) => f.Name.FirstName((Name.Gender?)u.Gender))
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.BirthDate, f => f.Person.DateOfBirth)
            .RuleFor(c => c.Gender, f => f.PickRandom<Gender>());


        return faker.Generate(count);

    }
}
