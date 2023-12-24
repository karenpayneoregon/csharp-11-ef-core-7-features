using EnumHasConversion.Data;
using EnumHasConversion.Models;
using static EnumHasConversion.Classes.SpectreConsoleHelpers;

namespace EnumHasConversion.Classes;

public class WineOperations
{
    public static List<Wine> GetWinesByType(WineType wineType)
    {
        using var context = new WineContext();
        return context.Wines
            .Where(wine => wine.WineType == wineType)
            .ToList();
    }
    public static void RunExamples()
    {
        using var context = new WineContext();
            
        LineSeparator("[white]Grouped[/]");
        List<WineGroupItem> allWinesGrouped = context.Wines
            .GroupBy( wine => wine.WineType)
            .Select(w => new WineGroupItem(w.Key, w.ToList()))
            .ToList();

        foreach (WineGroupItem top in allWinesGrouped)
        {
            AnsiConsole.MarkupLine($"[cyan]{top.Key}[/]");
            foreach (var wine in top.List)
            {
                Console.WriteLine($"\t{wine.WineId, -5}{wine.Name}");
            }
        }


        List<Wine> allWines = [.. context.Wines];
        
        LineSeparator("[white]All[/]");

        foreach (var wine in allWines)
        {
            AnsiConsole.MarkupLine($"[cyan]{wine.WineType,-8}[/]{wine.Name}");
        }


        List<Wine> rose = [.. context.Wines.Where(wine => wine.WineType == WineType.Rose)];

        LineSeparator("[white]Rose[/]");

        if (rose.Count == 0)
        {
            Console.WriteLine("\tNone");
        }
        else
        {
            foreach (var wine in rose)
            {
                Console.WriteLine($"{wine.Name,30}");
            }
        }
        
        LineSeparator("[white]Red[/]");


        List<Wine> red = [.. context.Wines.Where(wine => wine.WineType == WineType.Red)];

        foreach (Wine wine in red)
        {
            Console.WriteLine($"{wine.Name,30}");
        }

    }
}