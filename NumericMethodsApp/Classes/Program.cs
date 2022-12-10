using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace NumericMethodsApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample: Number methods";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
