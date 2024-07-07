using StringSyntaxWithEntityFrameworkCore.Models.Configuration;

namespace StringSyntaxWithEntityFrameworkCore.Classes.Configuration;
#nullable disable
/// <summary>
/// Known connection strings
/// </summary>
public sealed class DataConnections
{
    private static readonly Lazy<DataConnections> Lazy = new(() => new DataConnections());
    public static DataConnections Instance => Lazy.Value;

    public string MainConnection { get; set; }
}
public sealed class FormatSettings
{
    private static readonly Lazy<FormatSettings> Lazy = new(() => new FormatSettings());
    public static FormatSettings Instance => Lazy.Value;

    public ApplicationSetting Items { get; set; }
}
