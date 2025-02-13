﻿using System.Globalization;
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
            human.DisplayWithTable();
            Console.WriteLine();
        }

        var test = typeof(Customer).GetInterfaces().Select(x => x.Name);

        var entities = Helpers.GetAllEntityNames<IIdentity>();
        var entities1 = Helpers.GetAllEntities<IIdentity>();

        List<string> list =
        [
            "1|John|Doe|1990-01-01|Male|English",
            "2|Mary|Doe|1992-02-01|Female|English",
            "3|Mark|Smith|2000-02-01|Female|Spanish"
        ];

        List<Person> people = list.Select(x => Person.Parse(x, CultureInfo.InvariantCulture)).ToList();

        Console.ReadLine();

    }
}
