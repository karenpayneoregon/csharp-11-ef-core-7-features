using ReadPeopleWithCopilotChatDemo.Models;
using static System.Globalization.CultureInfo;

namespace ReadPeopleWithCopilotChatDemo.Classes;

public static class FileOperations
{
    public static async Task<List<Person>> ReadPeopleFromFile(string filePath)
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
