using ForEachIndexing.Models;

namespace ForEachIndexing.Classes;
internal class FileOperations
{
    public static List<Country> ReadCountryCodes(string filePath)
    {
        var countries = new List<Country>();

        if (!File.Exists(filePath))
        {
            return countries;
        }

        var lines = File.ReadAllLines(filePath)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToArray();

        foreach (var line in lines)
        {
            //if (string.IsNullOrWhiteSpace(line)) continue; // Skip empty lines

            var parts = line.Split(',');

            // Handle lines with missing code
            if (parts.Length == 2)
            {
                countries.Add(new Country
                {
                    Name = parts[0].Trim(),
                    Code = parts[1].Trim()
                });
            }
            else if (parts.Length == 1) // Missing code
            {
                countries.Add(new Country
                {
                    Name = parts[0].Trim(),
                    Code = "Unknown" // Placeholder for missing code
                });
            }
        }

        return countries;
    }
}
