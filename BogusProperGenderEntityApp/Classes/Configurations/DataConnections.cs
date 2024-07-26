namespace BogusProperGenderEntityApp.Classes.Configurations;
/// <summary>
/// Known connection strings
/// </summary>
public sealed class DataConnections
{
    private static readonly Lazy<DataConnections> Lazy = new(() => new DataConnections());
    public static DataConnections Instance => Lazy.Value;
    /// <summary>
    /// Database connection string from this application
    /// </summary>
    public string MainConnection { get; set; }

}