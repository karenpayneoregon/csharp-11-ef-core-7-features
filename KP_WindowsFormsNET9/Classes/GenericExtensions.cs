using KP_WindowsFormsNET9.Models;
using System.Buffers;

namespace KP_WindowsFormsNET9.Classes;
public static class GenericExtensions
{

    public static bool HasBannedWords(this ReadOnlySpan<char> text, SearchValues<string> bannedWords) =>
        text.ContainsAny(bannedWords);

    public static bool HasBannedWords(this string text, SearchValues<string> bannedWords) =>
        text.AsSpan().ContainsAny(bannedWords);

    public static bool HasBannedWords(this string text, params string[] bannedWords) => 
        text.AsSpan().ContainsAny(SearchValues.Create(bannedWords, StringComparison.OrdinalIgnoreCase));
}
