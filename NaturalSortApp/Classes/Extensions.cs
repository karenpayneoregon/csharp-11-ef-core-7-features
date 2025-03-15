using System.Text.RegularExpressions;

namespace NaturalSortApp.Classes;
public static partial class Extensions
{

    
    public static IEnumerable<string> NaturalOrderBy(this IEnumerable<string> me)
    {
        return me.OrderBy(x => NumbersRegex()
            .Replace(x, m => m.Value.PadLeft(50, '0')));
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumbersRegex();

}
