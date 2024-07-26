using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace GenerativeApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "A.I. Gemini Pro Code samples";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
