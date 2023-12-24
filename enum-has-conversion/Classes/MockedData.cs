using EnumHasConversion.Models;

namespace EnumHasConversion.Classes;

/// <summary>
/// Provides data for the DbContext in OnModelCreating
/// </summary>
public class MockedData
{
    public static List<WineTypes> WineTypes() =>
    [
        new() { Id = 1, TypeName = "Red", Description = "Classic red" },
        new() { Id = 2, TypeName = "White", Description = "Dinner white" },
        new() { Id = 3, TypeName = "Rose", Description = "Imported rose" }
    ];

    public static List<Wine> Wines() =>
    [
        new() { WineId = 1, Name = "Veuve Clicquot Rose", WineType = WineType.Red },
        new() { WineId = 2, Name = "Whispering Angel Rose", WineType = WineType.Rose },
        new() { WineId = 3, Name = "Pinot Grigi", WineType = WineType.White },
        new() { WineId = 4, Name = "Zinfandel", WineType = WineType.Rose },
        new() { WineId = 5, Name = "Banyuls Traditional French", WineType = WineType.Red },
        new() { WineId = 6, Name = "Louis Jdot", WineType = WineType.White }
    ];
}