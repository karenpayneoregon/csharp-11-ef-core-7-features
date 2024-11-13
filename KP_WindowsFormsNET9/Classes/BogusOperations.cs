using Bogus;

namespace KP_WindowsFormsNET9.Classes;

public class BogusOperations
{
    public static List<M1.Person> Persons(int count = 10)
    {
        
        int id = 1;  
        
        Randomizer.Seed = new(338);

        var faker = new Faker<M1.Person>()
            .RuleFor(c => c.Id, f => id++)

            .RuleFor(c => c.FirstName, (f, c) => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName());
        
        return faker.Generate(count);

    }

    
 
}