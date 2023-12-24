using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace EnumHasConversion;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "EF Core has conversion code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

}
