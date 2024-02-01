using System.Runtime.CompilerServices;
using ValidatorsApp.Classes;

// ReSharper disable once CheckNamespace
namespace ValidatorsApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        SetupLogging.Development();
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
