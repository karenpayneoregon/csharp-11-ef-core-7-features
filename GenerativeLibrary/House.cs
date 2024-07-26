namespace GenerativeLibrary;

public class House
{
    public int NumberOfFloors { get; private set; }
    public int NumberOfRooms { get; private set; }
    public bool HasGarage { get; private set; }
    public bool HasGarden { get; private set; }
    public string? Address { get; private set; }

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
        public string? Address { get; set; }

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

        public HouseBuilder WithAddress(string? address)
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
