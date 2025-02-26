namespace GlobbingImages.Models;

/// <summary>
/// Represents the parameters required for file matching operations, including the parent folder,
/// include patterns, and exclude patterns.
/// </summary>
/// <remarks>
/// This record is used to encapsulate the necessary data for performing file system globbing.
/// It includes the directory to search within, patterns to include, and patterns to exclude.
/// </remarks>
public record MatcherParameters
{
    public string ParentFolder { get; set; }
    public string[] Patterns { get; set; }
    public string[] ExcludePatterns { get; set; }
}