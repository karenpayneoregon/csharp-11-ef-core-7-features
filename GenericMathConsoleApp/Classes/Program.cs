using System.Runtime.CompilerServices;


// ReSharper disable once CheckNamespace
namespace GenericMathConsoleApp;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample: C# 11 - generic math";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

}