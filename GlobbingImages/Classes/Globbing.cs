using GlobbingImages.Models;
using Microsoft.Extensions.FileSystemGlobbing;

namespace GlobbingImages.Classes;

public class Globbing
{
    public static async Task<Func<List<string>>> GetImagesNamesAsync(MatcherParameters mp)
    {
        Matcher matcher = new();
        matcher.AddIncludePatterns(mp.Patterns);
        matcher.AddExcludePatterns(mp.ExcludePatterns);

        return await Task.FromResult(() => matcher.GetResultsInFullPath(mp.ParentFolder).ToList());
    }
}