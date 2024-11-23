using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using TaskDialogLibrary;

// ReSharper disable MethodOverloadWithOptionalParameter

namespace KP_WindowsFormsNET9.Classes;

public partial class OverloadResolutionPriorityDemo
{
    /// <summary>
    /// Displays the given invoice incremented by 1.
    /// </summary>
    /// <param name="invoice">The invoice to be displayed.</param>
    [OverloadResolutionPriority(2)]
    public static void DisplayInvoice(string invoice )
    {

        MessageBox.Show($"{invoice,-8}{NextValue(invoice)}");
    }

    /// <summary>
    /// Displays the given invoice incremented by 1 by the specified count.
    /// </summary>
    /// <param name="invoice">The invoice to be displayed.</param>
    /// <param name="count">The number of times to increment the invoice. Default is 3.</param>
    [OverloadResolutionPriority(-1)]
    public static void DisplayInvoice(string invoice, int count = 3)
    {
        StringBuilder sb = new();
        var value = invoice;
        for (var index = 0; index < count; index++)
        {
            value = NextValue(value);
            sb.AppendLine($"{invoice,-8}{value}");
        }

        MessageBox.Show(sb.ToString());
    }

    public static string NextValue(string sender, int incrementBy = 1)
    {
        var value = NumbersPattern().Match(sender).Value;
        return sender[..^value.Length] + (long.Parse(value) + incrementBy)
            .ToString().PadLeft(value.Length, '0');
    }

    [GeneratedRegex("[0-9]+$")]
    private static partial Regex NumbersPattern();
}