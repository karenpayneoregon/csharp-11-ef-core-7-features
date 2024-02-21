using BogusProperGenderApp.Classes;
using BogusProperGenderApp.Models;

namespace BogusProperGenderApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        List<Customer> list = BogusOperations.CustomersList(20);
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
}