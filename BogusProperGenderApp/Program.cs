using BogusProperGenderApp.Classes;
using BogusProperGenderApp.Models;
// ReSharper disable FormatStringProblem
// ReSharper disable CoVariantArrayConversion

namespace BogusProperGenderApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        List<Customer> list = BogusOperations.CustomersList(20,true);
        var table = CreateTable();
        foreach (var customer in list)
        {
            table.AddRow(customer.FirstName, customer.LastName,
                customer.Gender == Gender.Female
                    ? $"[deepskyblue3]{customer.Gender}[/]"
                    : customer.Gender.ToString()!, customer.BirthDay.ToString("MM/dd/yyyy"), customer.Email);
        }

        AnsiConsole.Write(table);

        SpectreConsoleHelpers.ExitPrompt();
    }

    private static void DisplayItems()
    {
        Console.WriteLine("{0}-{1}-{2}", 
            [1,2,3]);

        AnsiConsole.MarkupLine("[cyan]{0}[/]-[yellow]{1}[/]-[deeppink3_1]{2}[/]", 
            [1,2,3]);

        AnsiConsole.MarkupLine("[deeppink3_1]{0}[/][cyan]{1}[/][yellow]{2}[/] ", 
            // returns three customers
            BogusOperations.Customers);
    }

}