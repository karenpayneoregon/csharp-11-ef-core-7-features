namespace NodaTimeLibrary.Models;

/// <summary>
/// Represents the United States with its East Coast and West Coast time zones.
/// </summary>
public class UnitedStates
{
    /// <summary>
    /// Gets or sets the East Coast time zone.
    /// </summary>  
    public EastCoast EastCoast { get; init; } = new();

    /// <summary>
    /// Gets or sets the West Coast time zone.
    /// </summary>
    public WestCoast WestCoast { get; init; } = new();
}