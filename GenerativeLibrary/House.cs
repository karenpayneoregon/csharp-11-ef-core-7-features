namespace GenerativeLibrary;

public class House
{
    /// <summary>
    /// Gets the number of floors in the house.
    /// </summary>
    public int NumberOfFloors { get; private set; }

    /// <summary>
    /// Gets the number of rooms in the house.
    /// </summary>
    public int NumberOfRooms { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the house has a garage.
    /// </summary>
    public bool HasGarage { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the house has a garden.
    /// </summary>
    public bool HasGarden { get; private set; }

    /// <summary>
    /// Gets the address of the house.
    /// </summary>
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
        /// <summary>
        /// Gets or sets the number of floors for the house being built.
        /// </summary>
        public int NumberOfFloors { get; set; }

        /// <summary>
        /// Gets or sets the number of rooms for the house being built.
        /// </summary>
        public int NumberOfRooms { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the house being built has a garage.
        /// </summary>
        public bool HasGarage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the house being built has a garden.
        /// </summary>
        public bool HasGarden { get; set; }

        /// <summary>
        /// Gets or sets the address for the house being built.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Sets the number of floors for the house being built.
        /// </summary>
        /// <param name="floors">The number of floors.</param>
        /// <returns>The updated HouseBuilder instance.</returns>
        public HouseBuilder WithFloors(int floors)
        {
            NumberOfFloors = floors;
            return this;
        }

        /// <summary>
        /// Sets the number of rooms for the house being built.
        /// </summary>
        /// <param name="rooms">The number of rooms.</param>
        /// <returns>The updated HouseBuilder instance.</returns>
        public HouseBuilder WithRooms(int rooms)
        {
            NumberOfRooms = rooms;
            return this;
        }

        /// <summary>
        /// Sets whether the house being built has a garage.
        /// </summary>
        /// <param name="hasGarage">A value indicating whether the house has a garage.</param>
        /// <returns>The updated HouseBuilder instance.</returns>
        public HouseBuilder WithGarage(bool hasGarage)
        {
            HasGarage = hasGarage;
            return this;
        }

        /// <summary>
        /// Sets whether the house being built has a garden.
        /// </summary>
        /// <param name="hasGarden">A value indicating whether the house has a garden.</param>
        /// <returns>The updated HouseBuilder instance.</returns>
        public HouseBuilder WithGarden(bool hasGarden)
        {
            HasGarden = hasGarden;
            return this;
        }

        /// <summary>
        /// Sets the address for the house being built.
        /// </summary>
        /// <param name="address">The address of the house.</param>
        /// <returns>The updated HouseBuilder instance.</returns>
        public HouseBuilder WithAddress(string? address)
        {
            Address = address;
            return this;
        }

        /// <summary>
        /// Builds a new House instance based on the current HouseBuilder configuration.
        /// </summary>
        /// <returns>A new House instance.</returns>
        public House Build()
        {
            return new House(this);
        }
    }
}

