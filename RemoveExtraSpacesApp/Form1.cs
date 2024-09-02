using System.Diagnostics;
using System.Text.RegularExpressions;

namespace RemoveExtraSpacesApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void ExecuteButton_Click(object sender, EventArgs e)
    {
        if (Clipboard.ContainsText())
        {
            Clipboard.SetText(Clipboard.GetText().RemoveExtraWhitespace());
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Debug.WriteLine(Randomizing.NextValue());
    }
}

public static class Randomizing
{
    public static int NextValue()
    {
        return Random.Shared.Next(1,3);
    }
}
internal static partial class Extensions
{
    public static string RemoveExtraWhitespace(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }

        var chars = str.ToCharArray();
        //var start = 0;
        var end = 0;

        for (var index = 0; index < chars.Length; index++)
        {
            if (char.IsWhiteSpace(chars[index]))
            {
                if (index == 0)
                    continue;

                if (char.IsWhiteSpace(chars[index - 1]))
                    continue;
            }

            chars[end++] = chars[index];
        }

        return new(chars, 0, end);
    }
    public static string RemoveExtraSpaces(this string sender, bool trimEnd = true)
    {
        var result = MultipleSpacesRegex().Replace(sender, " ");
        return trimEnd ? result.TrimEnd() : result;

    }
    [GeneratedRegex("[ ]{2,}", RegexOptions.None)]
    private static partial Regex MultipleSpacesRegex();
}
