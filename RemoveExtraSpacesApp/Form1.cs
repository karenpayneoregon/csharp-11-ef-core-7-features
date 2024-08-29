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
            Clipboard.SetText(Clipboard.GetText().RemoveExtraSpaces());
        }
    }
}

internal static partial class Extensions
{
    public static string RemoveExtraSpaces(this string sender, bool trimEnd = true)
    {
        var result = MultipleSpacesRegex().Replace(sender, " ");
        return trimEnd ? result.TrimEnd() : result;

    }
    [GeneratedRegex("[ ]{2,}", RegexOptions.None)]
    private static partial Regex MultipleSpacesRegex();
}
