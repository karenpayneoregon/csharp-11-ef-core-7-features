using Bogus;
using Bogus.DataSets;
using BogusProperGenderApp.Models;
using Serilog;

namespace BogusProperGenderApp.Classes;

public class BogusOperations
{
    public static List<Customer> CustomersList(int count, bool finish)
    {
        
        int id = 1;  
        
        Randomizer.Seed = new(338);

        var faker = new Faker<Customer>()
            .RuleFor(c => c.Id, f => id++)
            .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
            .RuleFor(c => c.FirstName, (f, c) => f.Name.FirstName((Name.Gender?)c.Gender))
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.BirthDay, f => 
                f.Date.BetweenDateOnly(new DateOnly(1950, 1, 1), new DateOnly(2010, 1, 1)))
            .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName));

        if (finish)
        {
            ToObjectStructure(faker);
        }


        return faker.Generate(count);

    }

    private static void ToObjectDumper(Faker<Customer> faker)
    {
        //faker.FinishWith((f, c) => Log.Information("\n{@Customer}", ObjectDumper.Dump(c, DumpStyle.CSharp)));
        faker.FinishWith((f, c) => Log.Information("{@Customer}", ObjectDumper.Dump(c)));
    }
    private static void ToObjectStructure(Faker<Customer> faker)
    {
        faker.FinishWith((f, c) => Log.Information("\n{@Customer}", c));
        //faker.FinishWith((f, c) => Log.Information("\n{@Customer}", c.DumpAsJson()));
        //faker.FinishWith((f, c) => Log.Information("{@Customer}", c.Dump()));
    }
    private static void ToConsole(Faker<Customer> faker)
    {
        faker.FinishWith((f, c) =>
            Console.WriteLine($"{c.FirstName,-10}{c.LastName,-15}{c.Gender,-10}{c.BirthDay,-14:MM/dd/yyyy}{c.Email}"));
    }
}