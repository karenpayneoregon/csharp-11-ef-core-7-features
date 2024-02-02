using CommunityToolkit.Diagnostics;

namespace DiagnosticsGuardSampleApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        ArdalisGuard();
        //GoodInt(2);
        //BadInt(22);
        //GoodDateOnly(new DateOnly(2023, 12, 15));
        //BadDateOnly(new DateOnly(2023, 11, 15));
        Console.ReadLine();
    }

    private static void ArdalisGuard()
    {
        Product productGood = new Product("Mazda Miata", 1, 12m, new DateOnly(2024, 1, 11));
        try
        {
            Product productBad = new Product("Mazda Miata", 8, 12m, new DateOnly(2024, 1, 15));
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[hotpink2]{ex.Message}[/]");
        }
    }
    private static void GoodInt(int value)
    {
        Guard.IsBetween(value, 1, 4);
        AnsiConsole.MarkupLine("[yellow]Good int done[/]");
    }
    private static void BadInt(int value)
    {
        try
        {
            Guard.IsBetween(value, 1, 4);
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[hotpink2]{ex.Message}[/]");
        }
        AnsiConsole.MarkupLine("[yellow]Bad int done[/]");
    }

    public static void GoodDateOnly(DateOnly value)
    {
        Guard.IsBetween(value, new DateOnly(2023, 12, 12), new DateOnly(2023, 12, 24));
        AnsiConsole.MarkupLine("[yellow]Good DateOnly done[/]");
    }

    public static void BadDateOnly(DateOnly value)
    {
        try
        {
            Guard.IsBetween(value, new DateOnly(2023, 12, 12), new DateOnly(2023, 12, 24));
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[violet]{ex.Message}[/]");
        }
        AnsiConsole.MarkupLine("[yellow]Bad DateOnly done[/]");
    }
}