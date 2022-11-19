using System.Text.RegularExpressions;

namespace RawStringLiteralsApp.Classes;

public static class StringExtensions
{
    public static string SplitCamelCase(this string sender) =>
        string.Join(" ", Regex.Matches(sender, @"([A-Z][a-z]+)")
            .Select(m => m.Value));
    public static string ToYesNoString(this bool value) => (value ? "[cyan]Yes[/]" : "[red]No[/]");

}