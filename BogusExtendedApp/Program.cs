using Bogus;
using BogusExtendedApp.Classes;
using BogusExtendedApp.DataSets;
using BogusExtendedApp.LanguageExtensions;
using BogusExtendedApp.Models;

namespace BogusExtendedApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        var contacts = BogusOperations.Contacts();
        Console.WriteLine(ObjectDumper.Dump(contacts));

        Console.WriteLine();
        
        for (int index = 0; index < 3; index++)
        {
            var category = NorthWind.SingleCategory();
            Console.WriteLine($"{category.CategoryID,-4}{category.CategoryName,-30}{category.Description}");
            await Task.Delay(250);
        }
        
        Console.ReadLine();
    }
}