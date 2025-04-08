using System.Diagnostics;
using System.Text.Json;
#nullable disable

namespace NewStuffApp.Classes;
internal class Studio
{
    public static VisualStudioInstance? Details()
    {
        string fileName = @"C:\Program Files (x86)\Microsoft Visual Studio\Installer\vswhere.exe";

        if (!File.Exists(fileName))
        {
            return null;
        }

        var process = new Process
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
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        VisualStudioInstance[]? instances = JsonSerializer.Deserialize<VisualStudioInstance[]>(output, Options);

        var sorted = instances?
            .OrderByDescending(i => Version.TryParse(i.Catalog?.ProductDisplayVersion, out var v) ? v : new Version(0, 0))
            .ToList();

        return sorted?.FirstOrDefault(); 
    }

    public static JsonSerializerOptions Options => new() { PropertyNameCaseInsensitive = true };
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
}
