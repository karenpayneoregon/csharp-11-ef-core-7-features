using System.Text.Json;
using ForEachIndexing.Classes;

namespace ForEachIndexing;

internal partial class Program
{
    static void Main(string[] args)
    {


        //var people = JsonSerializer.Deserialize<List<Person>>(Json);
        //foreach (var (index, person) in people.Index())
        //{
        //    Console.WriteLine($"{index,-3}{person}");
        //}

        var countries = FileOperations.ReadCountryCodes("countrycodes.txt");
        foreach (var (index, country) in countries.Index())
        {
            if (country.Code == "Unknown")
            {
                Console.WriteLine($"{index,-3}{country}");
            }

        }

        //var lines = File.ReadAllLines("countrycodes.txt").ToArray();
        //foreach (var (index, item) in lines.Index())
        //{
        //    Console.WriteLine($"{index,-5}'{item}'");
        //}

        Console.ReadLine();
    }



    private static void IndexDemo()
    {
        var people = JsonSerializer.Deserialize<List<Person>>(Json);
        foreach (var (index, person) in people.Index())
        {
            Console.WriteLine($"{index,-3}{person}");
        }
    }
    public static string Json =>
        /*lang=json*/
        """
        [
          {
        	"FirstName": "Jose",
        	"LastName": "Fernandez",
        	"BirthDate": "1985-01-01"
          },
          {
        	"FirstName": "Miguel",
        	"LastName": "Lopez",
        	"BirthDate": "1970-12-04"
          },
          {
        	"FirstName": "Angel",
        	"LastName": "Perez",
        	"BirthDate": "1980-09-11"
          }
        ]
        """;
}


public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BirthDate { get; set; }
    public override string ToString() => $"{FirstName} {LastName} {BirthDate}";

}
