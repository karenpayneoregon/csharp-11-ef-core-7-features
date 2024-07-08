namespace FormattableStringSamples.Classes;
public static class Extensions
{
    public static (string name, object value) Deconstruct(this KeyValuePair<string, object> sender)
    {
        sender.Deconstruct(out var parameterName, out var parameterValue);
        return (parameterName, parameterValue);
    }

    public static string TableName(this FormattableString sender)
        => (string)sender.GetArguments()[0];

    public static string ArgumentsJoined(this FormattableString sender)
        => string.Join(",", sender.GetArguments());

    public static int Id(this FormattableString sender)
        => Convert.ToInt32(sender.GetArguments()[0].ToString());
    
    public static string FirstName(this FormattableString sender)
        => (string)sender.GetArguments()[1];

    public static string LastName(this FormattableString sender)
        => (string)sender.GetArguments()[2];

    public static DateOnly BirthDate(this FormattableString sender)
        => (DateOnly)sender.GetArguments()[3]!;

    public static void UpdateFirstName(this FormattableString sender, string value)
    {
        sender.GetArguments()[1] = value;
    }
    public static void UpdateLastName(this FormattableString sender, string value)
    {
        sender.GetArguments()[2] = value;
    }

    public static void UpdateBirthDate(this FormattableString sender, DateOnly value)
    {
        sender.GetArguments()[3] = value;
    }

    public static string ToYesNo(this bool value)
        => value ? "Yes" : "No";
}