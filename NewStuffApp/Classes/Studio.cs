using System.Diagnostics;
using System.Text.Json;
#nullable disable

namespace NewStuffApp.Classes;

/// <summary>
/// Represents a utility class for interacting with Visual Studio instances installed on the system.
/// </summary>
/// <remarks>
/// This class provides methods and properties to retrieve information about installed Visual Studio instances,
/// leveraging tools `vswhere.exe` for querying details.
/// </remarks>
public class Studio
{
    /// <summary>
    /// Retrieves details about the most recent Visual Studio instance installed on the system.
    /// </summary>
    /// <returns>
    /// A <see cref="VisualStudioInstance"/> object representing the most recent Visual Studio instance, 
    /// or <c>null</c> if no instance is found or the required tool is unavailable.
    /// </returns>
    /// <remarks>
    /// This method uses the `vswhere.exe` tool to query all installed Visual Studio instances, 
    /// including pre-release versions, and returns the instance with the highest version.
    /// </remarks>
    /// <exception cref="FileNotFoundException">
    /// Thrown if the `vswhere.exe` tool is not found at the expected location.
    /// </exception>
    /// <example>
    /// <code>
    /// var instance = Studio.Details();
    /// if (instance != null)
    /// {
    ///     Console.WriteLine($"Visual Studio: {instance.DisplayName}, Version: {instance.Catalog.ProductDisplayVersion}");
    /// }
    /// else
    /// {
    ///     Console.WriteLine("No Visual Studio instance found.");
    /// }
    /// </code>
    /// </example>
    public static VisualStudioInstance Details()
    {
        const string fileName = @"C:\Program Files (x86)\Microsoft Visual Studio\Installer\vswhere.exe";

        if (!File.Exists(fileName))
        {
            return null;
        }

        using Process process = new()
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = "-all -prerelease -products * -format json",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        process.Start();
        var output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        if (string.IsNullOrWhiteSpace(output))
            return null;

        var instances = JsonSerializer.Deserialize<VisualStudioInstance[]>(output, Options);
        return instances?
            .OrderByDescending(i => Version.TryParse(i.Catalog?.ProductDisplayVersion, 
                out var v) ? v : new Version(0, 0))
            .FirstOrDefault();
    }

    public static JsonSerializerOptions Options { get; } = new() { PropertyNameCaseInsensitive = true };
}


public class VisualStudioInstance
{
    public string DisplayName { get; set; }
    public string InstallationPath { get; set; }
    public CatalogInfo Catalog { get; set; }
}

public class CatalogInfo
{
    public string ProductDisplayVersion { get; set; }

    public Version ProductVersion => Version.TryParse(ProductDisplayVersion, out var version) ? version : new Version(0, 0);
}
