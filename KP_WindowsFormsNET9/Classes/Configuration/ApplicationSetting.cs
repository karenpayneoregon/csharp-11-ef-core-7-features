#nullable disable
namespace KP_WindowsFormsNET9.Classes.Configuration;

/// <summary>
/// Represents the application setting for, in this case is dark mode.
/// </summary>
public class ApplicationSetting
{
    public ConnectionStrings ConnectionStrings { get; set; }
    public EntityConfiguration EntityConfiguration { get; set; }

    public required VisualConfiguration VisualConfiguration { get; set; }
}

/// <summary>
/// Represents the visual configuration settings for the application.
/// </summary>
public class VisualConfiguration
{
    public required string SystemColorMode { get; set; }
}

public class ConnectionStrings
{
    public string MainConnection { get; set; }
    public string SecondaryConnection { get; set; }
}

public class EntityConfiguration
{
    public bool CreateNew { get; set; }
}