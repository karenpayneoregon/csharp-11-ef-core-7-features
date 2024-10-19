namespace ForumSurfingSamples.Classes.Configuration;

public sealed class EntitySettings
{
    private static readonly Lazy<EntitySettings> Lazy = new(() => new EntitySettings());
    public static EntitySettings Instance => Lazy.Value;
    /// <summary>
    /// Indicates if the database should be recreated
    /// </summary>
    public bool CreateNew { get; set; }
}