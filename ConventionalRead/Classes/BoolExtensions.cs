namespace ConventionalRead.Classes;

public static class BoolExtensions
{
    /// <summary>
    /// Converts a boolean value to its corresponding "Yes" or "No" string representation.
    /// </summary>
    /// <param name="value">The boolean value to convert.</param>
    /// <returns>
    /// A string "Yes" if the value is <see langword="true"/>; otherwise, "No".
    /// </returns>
    public static string ToYesNo(this bool value) =>
        value switch
        {
            true => "Yes",
            _ => "No"
        };
    /// <summary>
    /// Converts a string representation of a boolean value to its corresponding <see langword="true"/> or <see langword="false"/> value.
    /// </summary>
    /// <param name="value">The string representation of a boolean value. Expected values are "True" or "False".</param>
    /// <returns>
    /// <see langword="true"/> if the string is "True"; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool ToBool(this string value) =>
        value switch
        {
            "True" => true,
            _ => false
        };
}