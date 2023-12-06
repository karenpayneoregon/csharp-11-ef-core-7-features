
using ComplexTypesSampleApp.Classes;

namespace ComplexTypesSampleApp;
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await Setup();
        await Operations.ComplexTypesDemo();
        AnsiConsole.MarkupLine("[yellow]Done, see log file[/]");
        ExitPrompt();
    }
}