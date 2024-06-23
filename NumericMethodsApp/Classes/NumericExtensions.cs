namespace NumericMethodsApp.Classes;
public static class NumericExtensions
{
    public static bool IsEven(this int value) 
        => int.IsEvenInteger(value);

    public static bool IsPositive(this int value)
        => int.IsPositive(value);

    public static int MaxValue(this int value, int value2)
        => int.MaxMagnitude(value, value2);

    public static int MinValue(this int value, int value2)
        => int.MinMagnitude(value, value2);
}
