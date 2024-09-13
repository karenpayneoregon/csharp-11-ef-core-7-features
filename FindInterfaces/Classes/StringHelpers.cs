namespace FindInterfaces.Classes;
public static class StringHelpers
{
    public static string[] SplitStringOnLastBackslash(this string input)
    {
        int lastBackslashIndex = input.LastIndexOf('\\');
        if (lastBackslashIndex >= 0)
        {
            string directory = input[..lastBackslashIndex];
            string fileName = input[(lastBackslashIndex + 1)..];
            return new[] { directory, fileName };
        }
        else
        {
            return new[] { input };
        }
    }
}
