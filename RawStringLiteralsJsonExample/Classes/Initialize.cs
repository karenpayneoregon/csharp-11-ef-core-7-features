using System.Runtime.CompilerServices;
using ConsoleHelperLibrary.Classes;

namespace JsonExample.Classes;

internal class Initialize
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample: Raw string literals, json to xml";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}