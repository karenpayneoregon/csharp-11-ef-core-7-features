using CloneRecordApp.Classes;
using CloneRecordApp.Interfaces;
using CloneRecordApp.Models;
using System.Text.Json;

namespace CloneRecordApp;

internal partial class Program
{
    private static void Main()
    {
        Person person1 = new(id: 1, firstName: "Karen", lastName: "Payne", address:
        [
            new(id: 1, personId: 1, street: "978 Johnson St", city: "Portland", state: "OR"),
            new(id: 2, personId: 1, street: "123 Wyndmoor Ave", city: "Salem", state: "OR")
        ]);

        Person person2 = new(id: 2, firstName: "Jim", lastName: "Beam", address:
        [
            new(id: 1, personId: 2, street: "568 Happy Hollow Rd", city: "Clermont,", state: "KY")
        ]);

        /*
         * Complete duplicate of person1 including the primary key so be forewarned.
         */
        Person clone = person1 with { };

        Developer firstDeveloper = new()
        {
            Id = 3,
            FirstName = "Anne",
            LastName = "Noble",
            Address = [new Address(1, 3, "1234 Elm St", "Portland", "OR")],
            MainLanguage = "C#"
        };

        
        List<Person> list =
        [
            person1,
            person2,
            clone,
            firstDeveloper,
            // MainLanguage will be same as above record, C#
            firstDeveloper with
            {
                Id = 4, 
                FirstName = "Jim"
            },
            // MainLanguage will be different from the two above
            firstDeveloper with
            {
                Id = 5,
                MainLanguage = "F#",
                FirstName = "Cindy"
            }
        ];

        AnsiConsole.MarkupLine($"[springgreen4]{ObjectDumper.Dump(clone)}[/]");
        SpectreConsoleHelpers.LineSeparator();

        foreach (var person in list)
        {
            var (id, firstName, lastName, address) = person;
            if (person is IDeveloper developer)
            {
                AnsiConsole.MarkupLine($"[yellow]{id,-3} {firstName} {lastName} {developer.MainLanguage}[/]");
            }
            else
            {
                AnsiConsole.MarkupLine($"[salmon1]{id,-3} {firstName} {lastName}[/]");
            }
            
            foreach (var addr in address)
            {
                
                AnsiConsole.MarkupLine($"   [lightpink1]{addr.Id, -3} {addr.Street} {addr.City} {addr.State}[/]");
            }
        }

        SpectreConsoleHelpers.LineSeparator();

        List<Product> products = [];
        Dictionary<int, string> fruits = new()
        {
            [2] = "Pears",
            [3] = "Grapes",
            [4] = "Cherries"
        };
        var json = JsonSerializer.Serialize(fruits, Options);
        Product apples = new(1, "Apple", 2);
        products.Add(apples);

        foreach (var fruit in fruits)
        {
            // give all products the same category id
            products.Add(apples with { Id = fruit.Key, Name = fruit.Value });
        }

        //AnsiConsole.MarkupLine($"[thistle3]{ObjectDumper.Dump(products)}[/]");
        Console.WriteLine();
        CloneExample();
        Console.ReadLine();
    }

    private static void CloneExample()
    {
        var fruits = JsonSerializer.Deserialize<Dictionary<int, string>>(
            /*lang=json*/
            """
                 {
                   "2": "Pears",
                   "3": "Grapes",
                   "4": "Cherries"
                 }
                 """);
        List<Product> products = [];
        Product apples = new(1, "Apple", 2);
        products.Add(apples);

        foreach (var fruit in fruits)
        {
            products.Add(apples with { Id = fruit.Key, Name = fruit.Value });
        }

        var productList = products.Join(MockedData.Categories,
            product => product.CategoryId,
            category => category.CategoryId,
            (product, category) => new ProductItem(product, category))
            .ToList();

        foreach (var item in productList)
        {
            var (product, category) = item;
            Console.WriteLine($"Product: {product.Id} {product.Name,-10}{category.Name}");
        }

    }


    private static readonly JsonSerializerOptions Options = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true
    };

}