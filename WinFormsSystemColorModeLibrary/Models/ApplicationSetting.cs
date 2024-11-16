#nullable disable
using WinFormsSystemColorModeLibrary;

namespace WinFormsSystemColorModeLibrary.Models;

/// <summary>
/// Represents the application setting for, in this case is dark mode.
/// </summary>
public class ApplicationSetting
{
    public ConnectionStrings ConnectionStrings { get; set; }
    public EntityConfiguration EntityConfiguration { get; set; }

    public required VisualConfiguration VisualConfiguration { get; set; }
}