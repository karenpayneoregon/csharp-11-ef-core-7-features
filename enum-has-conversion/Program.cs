using EnumHasConversion.Classes;
using EnumHasConversion.Data;
using EnumHasConversion.Extensions;
using EnumHasConversion.Models;

using static EnumHasConversion.Classes.SpectreConsoleHelpers;

namespace EnumHasConversion;

internal partial class Program
{
    static void Main(string[] args)
    {
        using var context = new WineContext();

        CancellationTokenSource cancellationTokenSource = new(TimeSpan.FromSeconds(2));

        var success = context.CanConnectAsync(cancellationTokenSource.Token);
        if (success == false)
        {
            AnsiConsole.MarkupLine("[cyan]Creating and populating database[/]");
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            Console.Clear();
        }

        List<Wine> redWines = WineOperations.GetWinesByType(WineType.Red);

        WineOperations.RunExamples();

        ExitPrompt();
    }
}