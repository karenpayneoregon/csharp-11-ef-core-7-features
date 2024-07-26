**user**: create a C# class named House using the builder pattern

**cloud-gemini-pro**: 
## House Class with Builder Pattern in C#

```C#
public class House
{
    public int NumberOfFloors { get; private set; }
    public int NumberOfRooms { get; private set; }
    public bool HasGarage { get; private set; }
    public bool HasGarden { get; private set; }
    public string Address { get; private set; }

    private House(HouseBuilder builder)
    {
        NumberOfFloors = builder.NumberOfFloors;
        NumberOfRooms = builder.NumberOfRooms;
        HasGarage = builder.HasGarage;
        HasGarden = builder.HasGarden;
        Address = builder.Address;
    }

    public class HouseBuilder
    {
        public int NumberOfFloors { get; set; }
        public int NumberOfRooms { get; set; }
        public bool HasGarage { get; set; }
        public bool HasGarden { get; set; }
        public string Address { get; set; }

        public HouseBuilder WithFloors(int floors)
        {
            NumberOfFloors = floors;
            return this;
        }

        public HouseBuilder WithRooms(int rooms)
        {
            NumberOfRooms = rooms;
            return this;
        }

        public HouseBuilder WithGarage(bool hasGarage)
        {
            HasGarage = hasGarage;
            return this;
        }

        public HouseBuilder WithGarden(bool hasGarden)
        {
            HasGarden = hasGarden;
            return this;
        }

        public HouseBuilder WithAddress(string address)
        {
            Address = address;
            return this;
        }

        public House Build()
        {
            return new House(this);
        }
    }
}
```

This code defines a `House` class with a nested `HouseBuilder` class. The `HouseBuilder` class allows you to construct a `House` object step-by-step by setting its properties. Once all the desired properties are set, you can call the `Build()` method on the builder to create the final `House` object.

Here's an example of how to use the `House` class with the builder pattern:

```C#
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
```

This code will output the following:

```
Number of floors: 2
Number of rooms: 4
Has garage: True
Has garden: True
Address: 123 Main Street
```