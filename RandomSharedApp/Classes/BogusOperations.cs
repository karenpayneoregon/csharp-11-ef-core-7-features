using Bogus;
using RandomSharedApp.Models;

namespace RandomSharedApp.Classes;
internal class BogusOperations
{
    public static List<Human> People(int count = 15)
    {
        int identifier = 1;
        Faker<Human> fakePerson = new Faker<Human>()
            .CustomInstantiator(f => new Human(identifier++))
            .RuleFor(p => p.FirstName, f => f.Person.FirstName)
            .RuleFor(p => p.LastName, f => f.Person.LastName);

        return fakePerson.Generate(count);

    }
}
