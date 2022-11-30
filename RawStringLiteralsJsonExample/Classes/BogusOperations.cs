using Bogus;

namespace JsonExample.Classes;

public class BogusOperations
{
    /// <summary>
    /// Create random list of <see cref="Bogus.Person"/>
    /// </summary>
    /// <param name="count">Amount of people to create, passing nothing will create 10</param>
    /// <returns>List of Person</returns>
    public static List<Person> People(int count = 10)
    {
        int identifier = 1;

        Faker<Person> fakePerson = new Faker<Person>()
                .CustomInstantiator(f => new Person(identifier++))
                .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                .RuleFor(p => p.LastName, f => f.Person.LastName)
                .RuleFor(p => p.BirthDate, f => f.Date.Past(10))
            ;


        return fakePerson.Generate(count);

    }
}