using GenerativeApp.Classes;
using GenerativeLibrary;

namespace GenerativeApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        
        BuildHouse();
        SpectreConsoleHelpers.ExitPrompt();
    }

    private static void BuildHouse()
    {
        SpectreConsoleHelpers.PrintCyan();

        // Create a house with 2 floors, 4 rooms, a garage, and a garden at 123 Main Street
        House house = new House.HouseBuilder()
            .WithFloors(2)
            .WithRooms(4)
            .WithGarage(true)
            .WithGarden(true)
            .WithAddress("123 Main Street")
            .Build();

        // Print the house details
        Console.WriteLine($"Number of floors: {house.NumberOfFloors}");
        Console.WriteLine($"Number of rooms: {house.NumberOfRooms}");
        Console.WriteLine($"Has garage: {house.HasGarage}");
        Console.WriteLine($"Has garden: {house.HasGarden}");
        Console.WriteLine($"Address: {house.Address}");
    }
}