using System.Xml.Linq;

namespace UpdateFrameworkApp.Classes;

/// <summary>
/// Provides functionality to update the target framework of a .csproj file.
/// </summary>
/// <remarks>
/// Intent
/// - Use as an external tool for Visual Studio.
/// - Refactor as a dotnet tool
/// </remarks>
public class ProjectUpdater
{
    /// <summary>
    /// Updates the target framework of a specified .csproj file.
    /// </summary>
    /// <param name="csprojPath">The path to the .csproj file to be updated.</param>
    /// <param name="oldFramework">
    /// The current target framework to be replaced. Defaults to <c>net7.0</c>.
    /// </param>
    /// <param name="newFramework">
    /// The new target framework to set. Defaults to <c>net9.0</c>.
    /// </param>
    /// <returns>
    /// A message indicating the result of the update operation. This could be a success message,
    /// an error message if the file is not found, or a message indicating no changes were made.
    /// </returns>
    /// <exception cref="FileNotFoundException">
    /// Thrown if the specified .csproj file does not exist.
    /// </exception>
    /// <exception cref="System.Xml.XmlException">
    /// Thrown if the .csproj file is not a valid XML document.
    /// </exception>
    /// <exception cref="Exception">
    /// Thrown if an unexpected error occurs during the update process.
    /// </exception>
    public static string UpdateTargetFramework(string csprojPath, string oldFramework = "net7.0", string newFramework = "net9.0")
    {
        if (!File.Exists(csprojPath))
        {
            return $"[red]File not found:[/] {csprojPath}";
        }

        try
        {
            var doc = XDocument.Load(csprojPath);
            var targetFrameworkElement = doc.Root?.Element("PropertyGroup") ?.Element("TargetFramework");

            if (targetFrameworkElement == null)
            {
                return "[red]No <TargetFramework> element found.[/]";
            }

            if (targetFrameworkElement.Value.Trim() != oldFramework)
            {
                return $"[red]TargetFramework is not[/] [cyan]'{oldFramework}'[/],[red] found[/] [cyan]'" +
                       $"{targetFrameworkElement.Value}'[/]. [red]No changes made.[/]";
            }

            targetFrameworkElement.Value = newFramework;
            doc.Save(csprojPath);
            return $"[cyan]Updated TargetFramework to[/] '{newFramework}' [cyan]in[/] '{Path.GetFileName(csprojPath)}'.";
        }
        catch (Exception ex)
        {
            return $"Error updating file: {ex.Message}";
        }
    }
}