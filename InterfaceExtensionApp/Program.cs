using System.Globalization;
using InterfaceExtensionApp.Classes;
using InterfaceExtensionApp.Interfaces;
using InterfaceExtensionApp.Models;
using InterfaceLibrary;

namespace InterfaceExtensionApp;

internal partial class Program
{
    private static void Main()
    {

        var humans = MockedData.GetHumans();

        foreach (var human in humans)
        {
            human.DisplayWithTable();
            Console.WriteLine();
        }

        // set breakpoint below to see interfaces
        var usedInterfaces = typeof(Customer).GetInterfaces().Select(x => x.Name);

        List<string> entities = Helpers.GetAllEntityNames<IIdentity>();
        List<Type> entities1 = Helpers.GetAllEntities<IIdentity>();

        List<string> list =
        [
            "1|John|Doe|1990-01-01|Male|English",
            "2|Mary|Doe|1992-02-01|Female|English",
            "3|Mark|Smith|2000-02-01|Female|Spanish"
        ];

        List<Person> people = list.Select(x => Person.Parse(x, CultureInfo.InvariantCulture)).ToList();

        bool result = Helpers.ImplementsInterface<Customer, IBogus>();
        bool result1 = Helpers.ImplementsInterfaces<Customer>(typeof(IIdentity), typeof(IHuman));
        bool result2 = Helpers.ImplementsInterfaces<Customer>(typeof(IIdentity), typeof(IHuman), typeof(IBogus));
        IEnumerable<Type> result3 = Helpers.GetUnimplementedInterfaces<Customer>(typeof(IIdentity), typeof(IHuman), typeof(IBogus));

        Console.ReadLine();

    }
}
