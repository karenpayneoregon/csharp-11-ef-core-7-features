using NaturalSortApp.Classes;
using static NaturalSortApp.Classes.SpectreConsoleHelpers;

namespace NaturalSortApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Example();
        Example1();
        ExitPrompt();
    }

    private static async Task Example()
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

        //AnsiConsole.Write(resultsTable);

        //ExitPrompt();
        Directory.Delete(_filesFolder, true);
    }

    private static void Example1()
    {
        var fileNames = 
            """
            File1Test.txt
            File10Test.txt
            File2Test.txt
            File20Test.txt
            File3Test.txt
            File30Test.txt
            File4Test.txt
            File40Test.txt
            File5Test.txt
            File50Test.txt
            """.Split(Environment.NewLine);

        List<string> sorted = fileNames.NaturalOrderBy(x => x).ToList();
        sorted.ForEach(Console.WriteLine);

        var folder = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        var files = Directory.EnumerateFiles(folder.FullName, "*.*", new EnumerationOptions
        {
            IgnoreInaccessible = true,
            RecurseSubdirectories = true
        }).ToList();




        //var files = folder.EnumerateFiles("*.*", SearchOption.AllDirectories)
        //    .NaturalOrderBy(x => x.Name)
        //    .ToArray();
    }
}