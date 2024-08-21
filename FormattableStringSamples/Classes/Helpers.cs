using System.Text.RegularExpressions;

namespace FormattableStringSamples.Classes;

public partial class Helpers
{

    public static string NextValue(string value, int incrementBy = 1)
    {
        var current = NumbersPattern().Match(value).Value;
        return value[..^current.Length] + (long.Parse(current) + incrementBy)
            .ToString().PadLeft(current.Length, '0');
    }

    [GeneratedRegex("[0-9]+$")]
    private static partial Regex NumbersPattern();
}


