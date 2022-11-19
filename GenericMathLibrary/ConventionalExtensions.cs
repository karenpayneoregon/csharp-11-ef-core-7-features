namespace GenericMathLibrary;

public static class ConventionalExtensions
{
    public static bool AllDouble(this string[] sender)
        => sender.All(item => double.TryParse(item, out _));
    public static bool AllDecimal(this string[] sender)
        => sender.All(item => decimal.TryParse(item, out _));
    public static bool AllInt(this string[] sender)
        => sender.SelectMany(item => item.ToCharArray()).All(char.IsNumber);
}