# About

Examples for NuGet package [CommunityToolkit.Diagnostics](https://www.nuget.org/packages/CommunityToolkit.Diagnostics/8.2.2?_src=template), specifically [Guard.IsBetween Method](https://learn.microsoft.com/en-us/dotnet/api/microsoft.toolkit.diagnostics.guard.isbetween?view=win-comm-toolkit-dotnet-7.1).

The Guard.IsBetween is for asserting that an input value must be in a given interval (between) and if not throws an exception.

Two examples, one for `int`, one for `DateOnly`.

```csharp
using CommunityToolkit.Diagnostics;

namespace DiagnosticsGuardSampleApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        GoodInt(2);
        BadInt(22);
        GoodDateOnly(new DateOnly(2023, 12, 15));
        BadDateOnly(new DateOnly(2023, 11, 15));
        Console.ReadLine();
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
```