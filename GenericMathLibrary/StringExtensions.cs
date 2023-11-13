namespace GenericMathLibrary;
public static class StringExtensions
{
    /// <summary>
    /// Add ellipsis-es to the end of a string
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="width">Width to pad</param>
    /// <param name="paddingChar">Character to pad with, defaults to a period</param>
    /// <returns>Padded string</returns>
    public static string Ellipsis(this string? sender, int width, char paddingChar = '.')
    {
        return sender.PadRight(width, paddingChar);
    }
}
