using GenericMathConsoleApp.Classes;
using GenericMathLibrary;

namespace GenericMathConsoleApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        //RunMenu();
        string[] items = { "", "10.5", "" };
        var results = items.GetNonNumericIndexes<decimal>();
    }

    private static void RunMenu()
    {
        while (true)
        {
            Console.Clear();

            var menuItem = AnsiConsole.Prompt(MenuOperations.SelectionPrompt());
            if (menuItem.Id != -1)
            {
                menuItem.Action();
            }
            else
            {
                return;
            }
        }
    }
}