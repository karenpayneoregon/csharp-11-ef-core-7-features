namespace SolutionFinderApp.Models;

/// <summary>
/// Specifies the options available for scanning directories for solution files.
/// </summary>
/// <summary>
/// Scan all files in the directory.
/// </summary>
/// <summary>
/// Scan only files that contain warnings.
/// </summary>
public enum ScanOptions
{
    /// <summary>
    /// Scan all files in the directory and the warning file will mirror the main json file. When WarningsOnly is selected the result json file will have empty projects.
    /// </summary>
    All,
    /// <summary>
    /// Scan only files that contain warnings for security issues that are suppressed
    /// </summary>
    WarningsOnly
}