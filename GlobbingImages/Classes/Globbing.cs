using GlobbingImages.Models;
using Microsoft.Extensions.FileSystemGlobbing;

namespace GlobbingImages.Classes;

/// <summary>
/// Provides functionality for matching file system entries using include and exclude patterns.
/// </summary>
/// <remarks>
/// This class utilizes the <see cref="Matcher"/> to perform
/// pattern-based file matching. It is designed to simplify the process of retrieving file paths
/// that match specific criteria within a given directory.
/// </remarks>
public class Globbing
{
    /// <summary>
    /// Asynchronously retrieves a function that, when invoked, returns a list of image file paths
    /// matching the specified include and exclude patterns within a given directory.
    /// </summary>
    /// <param name="mp">
    /// An instance of <see cref="MatcherParameters"/> containing the parent folder path,
    /// include patterns, and exclude patterns for file matching.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result is a function that,
    /// when called, returns a list of file paths matching the specified criteria.
    /// </returns>
    /// <remarks>
    /// This method uses the <see cref="Matcher"/> class to perform pattern-based file matching.
    /// It simplifies the process of filtering file paths based on include and exclude patterns.
    /// </remarks>
    public static async Task<Func<List<string>>> GetImagesNamesAsync(MatcherParameters mp)
    {
        Matcher matcher = new();
        matcher.AddIncludePatterns(mp.Patterns);
        matcher.AddExcludePatterns(mp.ExcludePatterns);

        return await Task.FromResult(() => matcher.GetResultsInFullPath(mp.ParentFolder).ToList());
    }
}