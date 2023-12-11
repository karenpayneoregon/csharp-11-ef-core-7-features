namespace PatternMatchingApp1.Classes;
public static class LanguageExtensions
{
    public static bool IsConferenceDay(this DateOnly date)
        => date is { Month: 1, Day: 10 or 11 or 12 } or { Month: 3, Day: 8 or 9 or 10 };
}
