namespace CommaDelimitedStringCollectionSampleApp.Classes;

static class Extensions
{
    /// <summary>
    /// int array to string array
    /// </summary>
    /// <param name="sender"></param>
    public static string[] ToStringArray(this int[] sender)
        => sender.Select(x => x.ToString()).ToArray();


    public static string ToYesNo(this bool value) => value ? "Yes" : "No";
    public static string ToYesNo(this bool value, string yes, string no) => value ? "Yes" : "No";
}