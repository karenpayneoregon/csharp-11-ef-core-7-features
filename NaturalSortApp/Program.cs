using GenericMathLibrary;
using NaturalSortApp.Classes;
using Spectre.Console;
using static NaturalSortApp.Classes.SpectreConsoleHelpers;

namespace NaturalSortApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        AnsiConsole.Write(
            new Panel(new Text("Order file names naturally").Centered())
                .Expand()
                .SquareBorder()
                .Header("[lightgreen]Code sample[/]")
                .HeaderAlignment(Justify.Center));

        CleanUp();

        List<string> fileNames = BogusOperations.FileNames();
        foreach (var name in fileNames)
        {
            await File.WriteAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", name), "");
        }

        List<string> sorted = fileNames.NaturalOrderBy(x => x).ToList();

        var resultsTable = CreateTable();

        for (int index = 0; index < sorted.Count(); index++)
        {
            resultsTable.AddRow(sorted[index]);
        }

        AnsiConsole.Write(resultsTable);

        ExitPrompt();
        Directory.Delete(_filesFolder, true);
    }
}