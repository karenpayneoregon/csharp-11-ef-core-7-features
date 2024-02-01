using JsonExample.Classes;
using Spectre.Console;

namespace JsonExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var test = Json;
            var xml = SystemTextOperations.JsonToXml(Json);
            File.WriteAllText("Game.xml", xml);


            if (File.Exists(PeopleOperations.FileName))
            {
                NewtonOperations.ConvertJsonToXml();
                WindowHelpers.CenterLines("[white]Done[/]", "Inspect [cyan]People.xml[/] in the executable folder");
            }
            else
            {
                AnsiConsole.MarkupLine($"[white]Run[/] {nameof(Sample)} to create {PeopleOperations.FileName}");
            }

            Console.ReadLine();
        }

        public static string Json => """
                                     {
                                         "SquidGame": {
                                             "Genre": "Thriller",
                                             "Rating": {
                                                 "@Type": "Imdb",
                                                 "#text": "8.1"
                                             },
                                             "Stars": ["Lee Jung-jae", "Park Hae-soo"],
                                             "Budget": null
                                         }
                                     }
                                     """;
        /// <summary>
        /// Create People.json
        /// </summary>
        private static void Sample()
        {
            PeopleOperations.Save(BogusOperations.People(2));
            var people = PeopleOperations.Read();

            foreach (var person in people)
            {
                Console.WriteLine(person.Details);
            }

            people.Add(new Person()
            {
                Id = 3,
                FirstName = "Jim",
                LastName = "Smith",
                BirthDate = new DateTime(1990, 1, 1)
            });
            PeopleOperations.Save(people);
            Console.WriteLine();

            people = PeopleOperations.Read();
            foreach (var person in people)
            {
                Console.WriteLine(person.Details);
            }
        }


    }
}