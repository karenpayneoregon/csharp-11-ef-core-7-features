using System.Text.RegularExpressions;

namespace DistinctByApp.LanguageExtensions;
public static partial class GenericsExtensions
{

    public static string SplitCamelCase(this string sender) =>
        string.Join(" ", CamelCaseRegex.Matches(sender)
            .Select(m => m.Value));

    /// <summary>
    /// Regular expression pattern for matching camel case words.
    /// </summary>
    private static readonly Regex CamelCaseRegex = CasingRegex();
    [GeneratedRegex(@"([A-Z][a-z]+)")]
    private static partial Regex CasingRegex();
}
