using GenericMathConsoleApp.Classes;

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