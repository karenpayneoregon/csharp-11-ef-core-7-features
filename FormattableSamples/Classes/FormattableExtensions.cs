namespace FormattableSamples.Classes;
public static class FormattableExtensions
{

    public static string TableName(this FormattableString sender)
        => (string)sender.GetArguments()[0];

    /// <summary>
    /// Returns the Major component of <see cref="Version"/>
    /// </summary>
    /// <param name="sender"></param>
    /// <returns></returns>
    public static int Major(this FormattableString sender)
        => Convert.ToInt32(sender.GetArgument(0));

    public static int Minor(this FormattableString sender)
        => Convert.ToInt32(sender.GetArgument(1));
    public static int Build(this FormattableString sender)
        => Convert.ToInt32(sender.GetArgument(2));
    public static int Revision(this FormattableString sender)
        => Convert.ToInt32(sender.GetArgument(3));

    public static string ArgumentsJoined(this FormattableString sender)
        => string.Join(",", sender.GetArguments());

    public static string ItemsCombined(this FormattableString sender, string separator = " ")
        => string.Join(separator, sender.GetArguments());

    public static int Id(this FormattableString sender)
        => Convert.ToInt32(sender.GetArguments()[(int)PropertyItem.Id].ToString());
    
    public static string FirstName(this FormattableString sender)
        => (string)sender.GetArguments()[(int)PropertyItem.FirstName];

    public static string LastName(this FormattableString sender)
        => (string)sender.GetArguments()[(int)PropertyItem.LastName];

    public static DateOnly BirthDate(this FormattableString sender)
        => (DateOnly)sender.GetArguments()[(int)PropertyItem.BirthDate]!;

    public static void UpdateFirstName(this FormattableString sender, string value)
    {
        sender.GetArguments()[(int)PropertyItem.FirstName] = value;
    }
    public static void UpdateLastName(this FormattableString sender, string value)
    {
        sender.GetArguments()[(int)PropertyItem.LastName] = value;
    }

    public static void UpdateBirthDate(this FormattableString sender, DateOnly value)
    {
        sender.GetArguments()[(int)PropertyItem.BirthDate] = value;
    }

    public static (string name, object value) Deconstruct(this KeyValuePair<string, object> sender)
    {
        sender.Deconstruct(out var parameterName, out var parameterValue);
        return (parameterName, parameterValue);
    }

    public static (string cell, DateOnly value) Deconstruct(this KeyValuePair<string, DateOnly> sender)
    {
        sender.Deconstruct(out var cell, out var dateValue);
        return (cell, dateValue);
    }

}