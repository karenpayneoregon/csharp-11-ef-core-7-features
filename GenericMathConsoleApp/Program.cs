using GenericMathConsoleApp.Classes;
using GenericMathLibrary;

// ReSharper disable FunctionNeverReturns

namespace GenericMathConsoleApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        RunMenu();
    }

    private static void RunMenu()
    {
        while (true)
        {
            Console.Clear();

            var menuItem = AnsiConsole.Prompt(MenuOperations.SelectionPrompt());
            menuItem.Action();

        }
    }

    private static void ExtractNonNumericIndexes()
    {
        string[] items = ["", "10.5", ""];
        var results = items.GetNonNumericIndexes<decimal>();
    }
}