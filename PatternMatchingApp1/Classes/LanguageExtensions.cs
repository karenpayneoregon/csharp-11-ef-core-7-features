using System.Runtime.CompilerServices;

namespace PatternMatchingApp1.Classes;

/// <summary>
/// CallerArgumentExpression
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/caller-argument-expression
/// </summary>
public static class LanguageExtensions
{
    public static bool IsConferenceDay(this DateOnly date)
        => date is { Month: 1, Day: 10 or 11 or 12 } or { Month: 3, Day: 8 or 9 or 10 };

    public static void ShouldBe<T>(this T sender, T expected, [CallerArgumentExpression(nameof(sender))] string expression = null)
    {
        if (sender is not int number || expected is not int value) return;
        if (number != value)
        {
            Console.WriteLine($"`{number}` for `{expression}` should be {value}");
        }
    }
}
