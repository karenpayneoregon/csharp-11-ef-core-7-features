namespace FindInterfaces.Classes;
public static class StringHelpers
{
    public static string[] SplitStringOnLastBackslash(this string input)
    {
        int lastBackslashIndex = input.LastIndexOf('\\');
        if (lastBackslashIndex >= 0)
        {
            string directory = input.Substring(0, lastBackslashIndex);
            string fileName = input.Substring(lastBackslashIndex + 1);
            return new[] { directory, fileName };
        }
        else
        {
            return new[] { input };
        }
    }
}
