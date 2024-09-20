#nullable disable

using AspectsDumpApp.Models;

namespace AspectsDumpApp.Classes;

public class MockedData
{
    public static Dictionary<int, Human> GetDictionary()
    {
        return new Dictionary<int, Human>()
        {
            [1] = new() { Id = 23, FirstName = "Karen", LastName = "Payne" },
            [2] = new() { Id = 24, FirstName = "Anne", LastName = "Jenkins" },
            [3] = new() { Id = 25, FirstName = "Mike", LastName = "Burton" }
        };
    }

    public static List<Person> GetPersons()
    {
        return
        [
            new Person
            {
                Id = 1, FirstName = "Karen", LastName = "Payne", BirthDate = new DateOnly(1956, 9, 24),
                SSN = "123-45-6789",
                Address = new Address()
                {
                    Id = 1, Street = "123 Wyndmoor Ave", City = "Wyndmoor", State = "PA"
                }
            },
            new Person
            {
                Id = 2, FirstName = "Sam", LastName = "Smith", BirthDate = new DateOnly(1965, 7, 12),
                SSN = "987-65-4321",
                Address = new Address()
                {
                    Id = 2, Street = "3 Moore Ave", City = "Salem", State = "OR"
                }
            },
            new Person
            {
                Id = 3, FirstName = "Anne", LastName = "Jones", BirthDate = new DateOnly(1978, 3, 4),
                SSN = "456-78-9123",
                Address = new Address()
                {
                    Id = 3, Street = "36 Case St.", City = "Portland", State = "OR"
                }
            },
            new Person
            {
                Id = 4, FirstName = "John", LastName = "Doe", BirthDate = new DateOnly(1989, 11, 23),
                SSN = "789-12-3456",
                Address = new Address()
                {
                    Id = 4, Street = "77 Hart Ln.", City = "Bridgeport", State = "OR"
                }
            },
            new Person
            {
                Id = 5, LastName = "Adams",
                SSN = "654-32-1987"
            }
        ];
    }
}