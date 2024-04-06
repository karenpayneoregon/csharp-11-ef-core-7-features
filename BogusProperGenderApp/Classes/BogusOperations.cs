using Bogus;
using Bogus.DataSets;
using BogusProperGenderApp.Models;

namespace BogusProperGenderApp.Classes;

    public class BogusOperations
    {
        public static List<Customer> CustomersList(int count, bool finish)
        {

            Randomizer.Seed = new Random(338);

            var faker = new Faker<Customer>()
                .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
                .RuleFor(c => c.FirstName, (f, c) => f.Name.FirstName((Name.Gender?)c.Gender))
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.BirthDay, f => f.Date.BetweenDateOnly(new DateOnly(1950, 1, 1), new DateOnly(2010, 1, 1)))
                .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName));

            if (finish)
            {
                faker.FinishWith((f, c) => 
                    Console.WriteLine($"{c.FirstName,-10}" + 
                                      $"{c.LastName,-15}" + 
                                      $"{c.Gender,-10}" + 
                                      $"{c.BirthDay,-14:MM/dd/yyyy}" + 
                                      $"{c.Email}"));

            }


            return faker.Generate(count);

        }
    }