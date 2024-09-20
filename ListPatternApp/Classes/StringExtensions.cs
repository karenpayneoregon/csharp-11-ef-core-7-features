using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ListPatternApp.Classes;

public static partial class StringExtensions
{
    private static readonly Regex CamelCaseRegex = new(@"([A-Z][a-z]+)");
    /// <summary>
    /// KarenPayne => Karen Payne
    /// </summary>
    [DebuggerStepThrough]
    public static string SplitCamelCase(this string sender) =>
        string.Join(" ", CamelCaseRegex.Matches(sender)
            .Select(m => m.Value));
}