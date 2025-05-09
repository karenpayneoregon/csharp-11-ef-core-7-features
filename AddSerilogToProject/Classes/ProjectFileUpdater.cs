using System.Xml.Linq;

namespace AddSerilogToProject.Classes;

public class ProjectFileUpdater
{
    /// <summary>
    /// Adds Serilog package references to a given project file if they are not already present.
    /// </summary>
    /// <param name="fileName">The absolute path to the project file to be updated.</param>
    /// <remarks>
    /// This method checks for the existence of the project file and ensures that the required package references 
    /// ("Serilog.AspNetCore" and "SeriLogThemesLibrary") are included. If they are missing, it adds them to the 
    /// project file and saves the changes. If the file does not exist or an error occurs during the update, 
    /// appropriate messages are displayed.
    ///
    /// * Versions are not current on purpose.
    /// 
    /// </remarks>
    /// <exception cref="FileNotFoundException">Thrown if the specified project file does not exist.</exception>
    /// <exception cref="Exception">Thrown if an error occurs while processing the project file.</exception>
    public static void AddPackageReferences(string fileName)
    {
        // Should never happen but just in case a developer did not configure right for external tools.
        if (!File.Exists(fileName))
        {
            AnsiConsole.MarkupLine($"[{Color.Pink1}]File not found:[/] {fileName}");
            return;
        }

        try
        {
            var doc = XDocument.Load(fileName);
            var ns = doc.Root?.Name.Namespace ?? XNamespace.None;

            var existingPackages = doc.Descendants(ns + "PackageReference")
                .Select(pr => pr.Attribute("Include")?.Value)
                .Where(name => !string.IsNullOrEmpty(name))
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var needsUpdate = false;
            var itemGroup = new XElement(ns + "ItemGroup");

            if (!existingPackages.Contains("Serilog.AspNetCore"))
            {
                itemGroup.Add(new XElement(ns + "PackageReference",
                    new XAttribute("Include", "Serilog.AspNetCore"),
                    new XAttribute("Version", "7.0.0")));
                needsUpdate = true;
            }

            if (!existingPackages.Contains("SeriLogThemesLibrary"))
            {
                itemGroup.Add(new XElement(ns + "PackageReference",
                    new XAttribute("Include", "SeriLogThemesLibrary"),
                    new XAttribute("Version", "1.0.0.1")));
                needsUpdate = true;
            }

            if (needsUpdate)
            {
                doc.Root?.Add(itemGroup);
                doc.Save(fileName);
                AnsiConsole.MarkupLine($"[{Color.Pink1}]New package references added successfully.[/]");
            }
            else
            {
                AnsiConsole.MarkupLine($"[{Color.LightGreen}]All package references already exist.[/]");
            }
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[{Color.Pink1}]Error updating project file:[/] {ex.Message}");
        }
    }
}