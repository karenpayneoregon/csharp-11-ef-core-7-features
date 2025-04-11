using FieldKeywordSample.Interfaces;
using FieldKeywordSample.Models;

namespace FieldKeywordSample;

internal partial class Program
{
    static void Main(string[] args)
    {
        var people = People();

        foreach (var person in people)
        {
            {

                if (person is Customer customer)
                {
                    AnsiConsole.MarkupLine($"[cyan]{customer.Id} {customer.FirstName} {customer.LastName} {customer.BirthDate}[/]");
                }
                else
                {
                    AnsiConsole.MarkupLine($"[green]{person.Id} {person.FirstName} {person.LastName} {person.BirthDate}[/]");
                }
            }

            Console.WriteLine();

            {
                if (person is not Customer customer) continue;

                AnsiConsole.MarkupLine("[cyan]Customer[/]");
                Console.WriteLine($"    Customer ID: {customer.CustomerId}");
                Console.WriteLine();

                if (customer.Addresses is null) continue;

                AnsiConsole.MarkupLine("[cyan]    Address[/]");
                foreach (var address in customer.Addresses)
                {
                    Console.WriteLine($"        {address.FullAddress}");
                }

            }

            Console.WriteLine();
        }

        AnsiConsole.MarkupLine("[yellow]Exit[/]");
        Console.ReadLine();
    }

    private static List<IPerson> People()
    {
        List<IPerson> people =
        [
            new Customer
            {
                Id = 1,
                CustomerId = 100,
                FirstName = "mary",
                LastName = "smith",
                BirthDate = new DateOnly(1960,12,2)
            },

            new Customer
            {
                Id = 2,
                CustomerId = 200,
                FirstName = "john",
                LastName = "doe",
                BirthDate = new DateOnly(2000,1,7),
                Addresses =
                [
                    new Address
                    {
                        CustomerId = 2,
                        Street = "123 Main St",
                        City = "Any town",
                        State = "Ca",
                        ZipCode = "12345",
                        Country = "USA",
                        Phone = "555-555-5555"
                    },
                    new Address
                    {
                        CustomerId = 2,
                        Street = "456 Main St",
                        City = "Some town",
                        State = "Ca",
                        ZipCode = "12345",
                        Country = "USA",
                        Phone = "555-555-5566"
                    }
                ]
            },

            new Person
            {
                Id = 3,
                FirstName = "jane",
                LastName = "doe",
                BirthDate = new DateOnly(1978,8,15)
            }
        ];
        return people;
    }
}