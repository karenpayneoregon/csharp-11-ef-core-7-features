using UpdateFrameworkApp.Classes;

namespace UpdateFrameworkApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        var msg = ProjectUpdater.UpdateTargetFramework(args[0]);
        AnsiConsole.MarkupLine(msg);
        Console.ReadLine();
    }
}