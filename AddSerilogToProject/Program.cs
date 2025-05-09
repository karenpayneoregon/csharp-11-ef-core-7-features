using AddSerilogToProject.Classes;

namespace AddSerilogToProject;

internal partial class Program
{
    static void Main(string[] args)
    {
        ProjectFileUpdater.AddPackageReferences(args[0]);
        AnsiConsole.MarkupLine($"[{Color.Cyan1}]Press enter[/]");
        Console.ReadLine();
    }
}