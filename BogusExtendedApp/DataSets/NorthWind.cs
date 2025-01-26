using Bogus;
using BogusExtendedApp.Classes;
using BogusExtendedApp.LanguageExtensions;
using BogusExtendedApp.Models;
using System.Text.Json;

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

    private static Categories RandomCategory 
        => System.Random.Shared.GetItems(categories().ToArray(), 1)[0];
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
        return item;
    }

    private static List<Categories> categories()
    {
        List<Categories> list = JsonSerializer.Deserialize<List<Categories>>(JsonStatements.CategoriesData);
        foreach (var cat in list)
        {
            cat.Picture = cat.Photo.ByteToImage();
        }

        return list;
    }
}