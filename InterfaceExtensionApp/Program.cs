using System.Globalization;
using InterfaceExtensionApp.Classes;
using InterfaceExtensionApp.Interfaces;
using InterfaceExtensionApp.Models;

namespace InterfaceExtensionApp;

internal partial class Program
{
    private static void Main()
    {

        var humans = MockedData.GetHumans();

        foreach (var human in humans)
        {
            human.Display();
            Console.WriteLine();
        }

        var test = typeof(Customer).GetInterfaces().Select(x => x.Name);

        var entities = Helpers.GetAllEntityNames<IIdentity>();
        var entities1 = Helpers.GetAllEntities<IIdentity>();

        Person parsedPerson = Person.Parse("1,John,Doe,1990-01-01,Male,English\n", CultureInfo.InvariantCulture); 

        Console.ReadLine();

    }
}
