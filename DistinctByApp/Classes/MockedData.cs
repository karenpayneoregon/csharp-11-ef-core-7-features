using DistinctByApp.Models;

namespace DistinctByApp.Classes;

internal class MockedData
{
    public static IEnumerable<Movie> MovieList() =>
        new List<Movie>
        {
            new() { Id = 1, Name = "Inception", Released = 2010, Rating = 5 },
            new() { Id = 2, Name = "The Matrix", Released = 1999, Rating = 5},
            new() { Id = 3, Name = "Interstellar", Released = 2014, Rating = 5 },
            new() { Id = 4, Name = "The Dark Knight", Released = 2008, Rating = 5 },
            new() { Id = 5, Name = "Fight Club", Released = 1999, Rating = 4 },
            new() { Id = 6, Name = "Pulp Fiction", Released = 1994, Rating = 4 },
            new() { Id = 7, Name = "Forrest Gump", Released = 1994, Rating = 4 },
            new() { Id = 8, Name = "The Shawshank Redemption", Released = 1994, Rating = 5 },
            new() { Id = 9, Name = "The Godfather", Released = 1972, Rating = 5 },
            new() { Id = 10, Name = "The Godfather: Part II", Released = 1974, Rating = 5 }
        };

    public static IEnumerable<Member> MembersList1() =>
    [
        new() { Id = 1, Active = true, FirstName = "Mary", SurName = "Adams", Gender = Gender.Female},
        new() { Id = 2, Active = false, FirstName = "Sue", SurName = "Williams", Gender = Gender.Female},
        new() { Id = 3, Active = true, FirstName = "Jake", SurName = "Burns", Gender = Gender.Male},
        new() { Id = 4, Active = true, FirstName = "Jake", SurName = "Burns", Gender = Gender.Male},
        new() { Id = 5, Active = true, FirstName = "Clair", SurName = "Smith",Gender = Gender.Other},
        new() { Id = 6, Active = true, FirstName = "Mary", SurName = "Adams", Gender = Gender.Female },
        new() { Id = 7, Active = true, FirstName = "Sue", SurName = "Miller", Gender = Gender.Female }
    ];

    public static IEnumerable<Member> MembersList2() =>
    [
        new() { Id = 1, Active = true, FirstName = "Mary", SurName = "Adams", Gender = Gender.Female},
        new() { Id = 2, Active = false, FirstName = "Sue", SurName = "Williams", Gender = Gender.Female},
        new() { Id = 3, Active = false, FirstName = "Jake", SurName = "Burns", Gender = Gender.Male},
        new() { Id = 4, Active = true, FirstName = "Jake", SurName = "Burns", Gender = Gender.Male},
        new() { Id = 5, Active = true, FirstName = "Clair", SurName = "Smith",Gender = Gender.Other},
        new() { Id = 6, Active = true, FirstName = "Mary", SurName = "Adams", Gender = Gender.Female },
        new() { Id = 7, Active = true, FirstName = "Sue", SurName = "Miller", Gender = Gender.Female }
    ];

    public static IEnumerable<Member> MembersList3() =>
    [
        new() { Id = 1, Active = true, FirstName = "Mary", SurName = "Adams", Gender = Gender.Female},
        new() { Id = 2, Active = false, FirstName = "Sue", SurName = "Williams", Gender = Gender.Female},
        new() { Id = 1, Active = false, FirstName = "Jake", SurName = "Burns", Gender = Gender.Male},
        new() { Id = 4, Active = true, FirstName = "Jake", SurName = "Burns", Gender = Gender.Male},
        new() { Id = 5, Active = true, FirstName = "Clair", SurName = "Smith",Gender = Gender.Other},
        new() { Id = 1, Active = true, FirstName = "Mary", SurName = "Adams", Gender = Gender.Female },
        new() { Id = 7, Active = true, FirstName = "Sue", SurName = "Miller", Gender = Gender.Female }
    ];

    /// <summary>
    /// Here we are checking for duplicates by <see cref="Address"/> properties
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<Member> MembersList4() =>
    [
        new()
        {
            Id = 1, 
            Active = true, 
            FirstName = "Mary", 
            SurName = "Adams", 
            Gender = Gender.Female,
            Address = new() { Id = 1, Street = "123 Main St", City = "Portland", State = "NY" }
        },
        new()
        {
            Id = 2, 
            Active = false, 
            FirstName = "Sue", 
            SurName = "Williams", 
            Gender = Gender.Female,
            Address = new() { Id = 2, Street = "124 Main St", City = "Anytown", State = "NY" }
        },
        new()
        {
            Id = 3, 
            Active = false, 
            FirstName = "Jake", 
            SurName = "Burns", 
            Gender = Gender.Male,
            Address = new() { Id = 3, Street = "123 Main St", City = "Anytown", State = "CA" }
        },
        new()
        {
            Id = 4, 
            Active = true, 
            FirstName = "Jake", 
            SurName = "Burns", 
            Gender = Gender.Male,
            Address = new() { Id = 4, Street = "123 Main St", City = "Anytown", State = "PA" }
        },
        new()
        {
            Id = 5,
            Active = true, 
            FirstName = "Clair", 
            SurName = "Smith",
            Gender = Gender.Other,
            Address = new() { Id = 5, Street = "123 Main St", City = "Anytown", State = "NJ" }
        },
        new()
        {
            Id = 6, 
            Active = true, 
            FirstName = "Mary", 
            SurName = "Adams", 
            Gender = Gender.Female,
            Address = new() { Id = 1, Street = "123 Main St", City = "Portland", State = "NY" }
        }
    ];

}