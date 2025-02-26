namespace GlobbingImages.Models;

public record MatcherParameters
{
    public string ParentFolder { get; set; }
    public string[] Patterns { get; set; }
    public string[] ExcludePatterns { get; set; }
}