using InterfaceExtensionApp.Interfaces;
using InterfaceExtensionApp.Models;

namespace InterfaceExtensionApp.Classes;

internal class MockedData
{
    public static List<IHuman> GetHumans() =>
    [
        new Person()
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateOnly(1980, 1, 1),
            Gender = Gender.Male
        },
        new Customer()
        {
            Id = 2,
            FirstName = "Jane",
            LastName = "Smith",
            DateOfBirth = new DateOnly(1990, 12, 7),
            Gender = Gender.Female
        }
    ];
}


