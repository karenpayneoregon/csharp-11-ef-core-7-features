using System.Text.RegularExpressions;

namespace GenericMathConsoleApp.Classes;

public static partial class StringExtensions
{
    public static string SplitCamelCase(this string sender) =>
        string.Join(" ", CamelCaseRegex().Matches(sender)
            .Select(m => m.Value));
    public static string ToYesNoString(this bool value) => (value ? "[cyan]Yes[/]" : "[red]No[/]");
    
    [GeneratedRegex(@"([A-Z][a-z]+)")]
    private static partial Regex CamelCaseRegex();
}