using ReadPeopleWithCopilotChatDemo.Models;
using static System.Globalization.CultureInfo;

namespace ReadPeopleWithCopilotChatDemo.Classes;

public static class FileOperations
{
    /// <summary>
    /// Reads a list of people from a specified file.
    /// </summary>
    /// <param name="filePath">The path to the file containing the data of people.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Person"/> objects read from the file.</returns>
    /// <remarks>
    /// The file is expected to have data in the following format:
    /// Each person's data spans three consecutive lines:
    /// - First line: First name
    /// - Second line: Last name
    /// - Third line: Birth date in "MM/dd/yyyy" format
    /// Blank lines are ignored.
    /// </remarks>
    /// <exception cref="FormatException">Thrown if the birthdate format is invalid.</exception>
    /// <exception cref="IOException">Thrown if there is an error reading the file.</exception>
    public static async Task<List<Person>> ReadAsync(string filePath)
    {
        var people = new List<Person>();

        var lines = (await File.ReadAllLinesAsync(filePath))
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToArray();

        for (var index = 0; index < lines.Length; index += 4)
        {
            if (index + 2 >= lines.Length) continue;
            
            var firstName = lines[index];
            var lastName = lines[index + 1];
            var birthDate = DateOnly.ParseExact(lines[index + 2].Trim(), "MM/dd/yyyy", InvariantCulture);

            people.Add(new Person
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate
            });
        }

        return people;

    }
}
