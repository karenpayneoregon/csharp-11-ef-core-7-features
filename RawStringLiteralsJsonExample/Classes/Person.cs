
using System.Text.Json.Serialization;

namespace JsonExample.Classes;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public Person(int identifier)
    {
        Id = identifier;
    }

    public Person() { }

     [JsonIgnore]
    public string Details => $"{Id,-4}{FirstName} {LastName} {BirthDate:d}";
}