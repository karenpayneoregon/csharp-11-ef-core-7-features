
using NameOfSpecialSample.Classes;
using NameOfSpecialSample.Models;
using System.Runtime.CompilerServices;

namespace NameOfSpecialSample;
internal partial class Program
{
    static void Main(string[] args)
    {
        Customers customers = new() {CompanyName = "ABC"};
        var path1 = StringHelper.NameOf(() => customers.CountryIdentifierNavigation.Name);
        Console.WriteLine(path1);

        Orders details = new();
        var path2 = StringHelper.NameOf(() => details.CustomerIdentifierNavigation.CompanyName);
        Console.WriteLine(path2);

        Employees employees = new();
        var path3 = StringHelper.NameOf(() => employees.ContactTypeIdentifierNavigation.ContactTitle);
        Console.WriteLine(path3);

        var path4 = StringHelper.NameOf(() => employees.ContactTypeIdentifierNavigation.ContactTitle,false);
        Console.WriteLine(path4);

        var path5 = StringHelper.NameOf(() => customers.Contact.FullName);
        Console.WriteLine(path5);

        var path6 = StringHelper.NameOf(() => customers.Contact.FullName);
        Console.WriteLine(path6);

        var test = $"{nameof(Orders)}.{nameof(OrderDetails)}.{nameof(Products)}";
        Console.WriteLine(test);

        var result = StringHelper.NameOf<Customers>(x => x.Contact.FullName);
        Console.WriteLine(result);


        ExitPrompt();
    }

    static string StringOf(string value, [CallerArgumentExpression(nameof(value))] string fullpath = default!)
    {

        string outputString = fullpath.Substring(
            fullpath.IndexOf($"(", StringComparison.Ordinal) + 1, fullpath.IndexOf(')') - fullpath.IndexOf($"(", StringComparison.Ordinal) - 1);

        return outputString;
    }
}