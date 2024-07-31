namespace CommaDelimitedStringCollectionSampleApp.Classes;

internal static class FileHelpers
{
    /// <summary>
    /// Find files with no regard to if the user has permissions
    /// </summary>
    /// <param name="path">Folder name to check</param>
    /// <param name="extensions">file extensions</param>
    /// <returns></returns>
    public static string[] FilterFiles(string path, params string[] extensions)
        => extensions
            .Select(filter => $"*.{filter}")
            .SelectMany(item =>
                Directory.EnumerateFiles(
                    path,
                    item,
                    SearchOption.AllDirectories)).ToArray();
}