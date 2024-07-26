namespace BogusProperGenderEntityApp.Classes.Configurations;

/// <summary>
/// Represents the settings creating mocked Bogus data.
/// </summary>
public sealed class EntitySettings
{
    private static readonly Lazy<EntitySettings> Lazy = new(() => new EntitySettings());
    public static EntitySettings Instance => Lazy.Value;

    /// <summary>
    /// Gets or sets a value indicating whether the database should be recreated.
    /// This property is set to true only when running under Visual Studio Debugger in the DbContext OnConfiguring method.
    /// </summary>
    public bool CreateNew { get; set; }
}
