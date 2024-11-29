using BinaryFormatterAlternate.Models;

namespace BinaryFormatterAlternate.Classes;

internal class MockedData
{
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
            }
        ];
    }

    public static List<Friend> Friends()
    {
        return
        [
            new Friend
            {
                Id = 1, 
                FirstName = "Karen", 
                LastName = "Payne", 
                BirthDate = new DateOnly(1956, 9, 24),
                CellPhone = "123-456-7890"
            },
            new Friend
            {
                Id = 2, 
                FirstName = "Sam", 
                LastName = "Smith", 
                BirthDate = new DateOnly(1965, 7, 12),
                CellPhone = "987-654-3210"
            },
            new Friend
            {
                Id = 3, 
                FirstName = "Anne", 
                LastName = "Jones", 
                BirthDate = new DateOnly(1978, 3, 4),
                CellPhone = "456-789-1230"
            },
            new Friend
            {
                Id = 4, 
                FirstName = "John", 
                LastName = "Doe", 
                BirthDate = new DateOnly(1989, 11, 23),
                CellPhone = "789-123-4560"
            },
            new Friend
            {
                Id = 5, 
                FirstName = "Jane", 
                LastName = "Doe", 
                BirthDate = new DateOnly(1990, 12, 25),
                CellPhone = "654-321-9870"
            }

        ];
    }
}
