using System.ComponentModel;
using System.Globalization;

namespace GetBirthDateApp.Controls;

public class NumericTextBox : TextBox
{
    private readonly char _decimalSeparator =
        CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

    public NumericTextBox()
    {
        TextAlign = HorizontalAlignment.Right;
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {

        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != _decimalSeparator)
        {
            e.Handled = true;
        }

        if (e.KeyChar == _decimalSeparator && Text.IndexOf(_decimalSeparator) > -1)
        {
            e.Handled = true;
        }

        base.OnKeyPress(e);

    }

    [Browsable(false)]
    public int Integer => int.TryParse(Text, out var value) ? value : 0;

    [Browsable(false)]
    public decimal Decimal => decimal.TryParse(Text, out var value) ? value : 0;

    [Browsable(false)]
    public double Double => double.TryParse(Text, out var value) ? value : 0;

    public bool HasValue() => !string.IsNullOrWhiteSpace(Text);

    int WM_PASTE = 0x0302;
    protected override void WndProc(ref Message message)
    {
        if (message.Msg == WM_PASTE)
        {
            var clipboardData = Clipboard.GetDataObject();
            var input = (string)clipboardData?.GetData(typeof(string))!;
            int count = 0;

            foreach (var c in input)
            {
                if (c != _decimalSeparator) continue;
                count++;
                if (count > 1)
                {
                    return;
                }
            }

            foreach (var character in input)
            {
                if (char.IsControl(character) || char.IsDigit(character) || character == _decimalSeparator) continue;
                message.Result = (IntPtr)0;
                return;

            }
        }

        base.WndProc(ref message);

    }
}