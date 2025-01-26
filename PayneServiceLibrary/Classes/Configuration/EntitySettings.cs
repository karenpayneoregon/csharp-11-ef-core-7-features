namespace PayneServiceLibrary.Classes.Configuration;
/// <summary>
/// Represents the configuration settings for an entity within the application.
/// This class provides a singleton instance to manage and access entity-specific settings.
/// </summary>
public sealed class EntitySettings
{
    private static readonly Lazy<EntitySettings> Lazy = new(() => new EntitySettings());
    public static EntitySettings Instance => Lazy.Value;
    /// <summary>
    /// Indicates if the database should be recreated
    /// </summary>
    /// <remarks>
    /// Used for all connections
    /// </remarks>
    public bool CreateNew { get; set; }
}