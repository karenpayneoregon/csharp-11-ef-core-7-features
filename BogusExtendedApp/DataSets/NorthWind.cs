using Bogus;
using BogusExtendedApp.LanguageExtensions;
using BogusExtendedApp.Models;

namespace BogusExtendedApp.DataSets;

public class NorthWind : DataSet
{
    /// <summary>
    /// Pre-defined contact titles
    /// </summary>
    private static string[] contactTitles { get; } = [
        "Accounting Manager", 
        "Assistant Sales Agent", 
        "Assistant Sales Representative",
        "Marketing Assistant",
        "Marketing Manager", 
        "Order Administrator", 
        "Owner", 
        "Owner/Marketing Assistant", 
        "Sales Agent",
        "Sales Associate", 
        "Sales Manager", 
        "Sales Representative", 
        "Vice President, Sales"
    ];

    public string ContactTypeNames()
        => Random.ArrayElement(contactTitles);

    

    public ContactType ContactTypes()
    {
        var data = new Faker<ContactType>()
            .RuleFor(p => p.ContactTypeIdentifier, p => p.Random.Int(1, 10))
            .RuleFor(p => p.ContactTitle, f => f.NorthWind().ContactTypeNames());

        return data.Generate();

    }

    private static Categories RandomCategory => System.Random.Shared.GetItems(categories().ToArray(), 1)[0];
    /// <summary>
    /// Sample to control data returned
    /// </summary>
    /// <remarks>
    /// Really can be done without Bogus
    /// </remarks>
    public static Categories SingleCategory()
    {
        var item = RandomCategory;
        var faker = new Faker<Categories>();
        Categories cat = faker.Generate();
        cat.CategoryID = item.CategoryID;
        cat.CategoryName = item.CategoryName;
        cat.Description = item.Description;
        return cat;
    }

    private static List<Categories> categories() =>
    [
        new Categories() { CategoryID = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" },
        new Categories() { CategoryID = 2, CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" },
        new Categories() { CategoryID = 3, CategoryName = "Confections", Description = "Desserts, candies, and sweet breads" },
        new Categories() { CategoryID = 4, CategoryName = "Dairy Products", Description = "Cheeses" },
        new Categories() { CategoryID = 5, CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" },
        new Categories() { CategoryID = 6, CategoryName = "Meat/Poultry", Description = "Prepared meats" },
        new Categories() { CategoryID = 7, CategoryName = "Produce", Description = "Dried fruit and bean curd" },
        new Categories() { CategoryID = 8, CategoryName = "Seafood", Description = "Seaweed and fish" },
        new Categories() { CategoryID = 9, CategoryName = "Wine", Description = "Wine" }
    ];
}