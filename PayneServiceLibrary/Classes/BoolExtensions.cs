namespace PayneServiceLibrary.Classes
{
    public static class BoolExtensions
    {
        public static string ToYesNo(this bool value) =>
            value switch
            {
                true => "Yes",
                _ => "No"
            };
    }
}
