using System.Globalization;
using ReadPeopleWithCopilotChatDemo.Models;

namespace ReadPeopleWithCopilotChatDemo.Classes
{
    public static class FileOperations
    {
        public static List<Person> ReadPeopleFromFile(string filePath)
        {
            var people = new List<Person>();

            var lines = File.ReadAllLines(filePath)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToArray();

            for (int index = 0; index < lines.Length; index += 4)
            {
                if (index + 2 < lines.Length)
                {
                    var firstName = lines[index].Trim();
                    var lastName = lines[index + 1].Trim();
                    var birthDate = DateOnly.ParseExact(lines[index + 2].Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    people.Add(new Person
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        BirthDate = birthDate
                    });
                }
            }
            return people;
        }
    }
}
