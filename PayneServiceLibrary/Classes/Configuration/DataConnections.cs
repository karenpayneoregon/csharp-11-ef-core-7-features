namespace PayneServiceLibrary.Classes.Configuration;
#nullable disable
/// <summary>
/// Known connection strings
/// </summary>
public sealed class DataConnections
{
    private static readonly Lazy<DataConnections> Lazy = new(() => new DataConnections());
    public static DataConnections Instance => Lazy.Value;

    /// <summary>
    /// Gets or sets the main connection string used by the application.
    /// </summary>
    /// <remarks>
    /// This property holds the primary connection string required for database operations. 
    /// It is typically initialized from the application's configuration settings and 
    /// accessed via the singleton instance of <see cref="DataConnections"/>.
    /// </remarks>
    public string MainConnection { get; set; }

    public string SecondaryConnection { get; set; }
}
