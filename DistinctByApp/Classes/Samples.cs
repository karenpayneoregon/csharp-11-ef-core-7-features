
using DistinctByApp.LanguageExtensions;
using DistinctByApp.Models;

namespace DistinctByApp.Classes;
internal class Samples
{

    /// <summary>
    /// Displays a distinct list of movies based on their release year.
    /// </summary>
    /// <remarks>
    /// This method retrieves a list of movies, filters them to ensure each release year is unique,
    /// and then prints the distinct movies to the console with their index, ID, name, and release year.
    /// </remarks>
    public static void DistinctByMovieReleasedYear()
    {

        PrintCyan();
        
        var distinctList = MockedData.MovieList()
            .DistinctBy(movie => movie.Released)
            .ToList();



        MovieHeader();

        foreach (var (index, item) in distinctList.Index())
        {
            Console.WriteLine($"{index,-7}{item.Id,-10}{item.Name,-25}{item.Released}");
        }

    }


    /// <summary>
    /// Groups a list of movies by their release year and selects the first movie from each group.
    /// </summary>
    /// <remarks>
    /// This method retrieves a list of movies, groups them by their release year, 
    /// and then selects the first movie from each group.  
    /// </remarks>
    public static void GroupMoviesOnReleased()
    {

        PrintCyan();

        var distinctList = 
            MockedData.MovieList()
                .GroupBy(m => m.Released)
                .Select(g => g.First())
                .ToList();

        MovieHeader();

        foreach (var (index, movie) in distinctList.Index())
        {
            Console.WriteLine($"{index,-7}{movie.Id,-10}{movie.Name,-25}{movie.Released}");
        }
    }

    /// <summary>
    /// Groups movies by whether their name starts with "The" and their rating, 
    /// then prints the grouped movies to the console.
    /// </summary>
    /// <remarks>
    /// This method uses the <see cref="MockedData.MovieList"/> to retrieve a list of movies.
    /// It groups the movies based on whether their name starts with "The" (case-insensitive) 
    /// and their rating. The grouped movies are then printed to the console, displaying 
    /// the group key (whether the name starts with "The" and the rating) and the details 
    /// of each movie in the group.
    /// </remarks>
    public static void GroupMoviesNameStartsWithAndRating()
    {

        PrintCyan();

        var moviesGroupedByNameAndRating = MockedData.MovieList()
            .GroupBy(m => new MovieItem(
                m.Name.StartsWith("The", StringComparison.OrdinalIgnoreCase), 
                m.Rating));


        AnsiConsole.MarkupLine($"[{Color.Chartreuse1}][u]Name                      Released    Rating[/][/]");
        foreach (var group in moviesGroupedByNameAndRating)
        {
            if (!group.Key.StartsWithThe) continue;
            foreach (var movie in group)
            {
                Console.WriteLine($"{movie.Name, -25} {movie.Released, -12}{movie.Rating}");
            }

        }
    }

    /// <summary>
    /// Filters a list of members to include only distinct entries based on their first and last names.
    /// </summary>
    /// <remarks>
    /// This method retrieves a list of members, filters out duplicates based on the combination of 
    /// <see cref="Member.FirstName"/> and <see cref="Member.SurName"/>, and then prints the distinct members 
    /// to the console with their index, ID, first name, and surname.
    /// </remarks>
    public static void DistinctByFirstLastNames()
    {

        PrintCyan();

        var distinctList = MockedData.MembersList1()
            .DistinctBy(member => new
            {
                member.FirstName,
                member.SurName
            })
            .ToList();

        MemberHeader();

        foreach (var (index, item) in distinctList.Index())
        {
            Console.WriteLine($"{index, -7}{item.Id, -10}{item.FirstName, -10}{item.SurName}");
        }
    }

    /// <summary>
    /// Filters a list of members to include only distinct entries based on their first name, surname, and active status.
    /// </summary>
    /// <remarks>
    /// This method retrieves a list of members, filters out duplicates based on the combination of 
    /// <see cref="Member.FirstName"/>, <see cref="Member.SurName"/>, and <see cref="Member.Active"/> properties, 
    /// and then prints the distinct members to the console.
    /// </remarks>
    public static void DistinctByFirstLastNameAndActive()
    {

        PrintCyan();

        var distinctList = MockedData.MembersList1()
            .DistinctBy(member => new
            {
                member.FirstName,
                member.SurName,
                member.Active
            })
            .ToList();

        MemberHeader();

        foreach (var (index, item) in distinctList.Index())
        {
            Console.WriteLine($"{index,-7}{item.Id,-10}{item.FirstName,-10}{item.SurName}");
        }
    }

    /// <summary>
    /// Filters a list of members to include only distinct entries based on their primary key (Id).
    /// </summary>
    /// <remarks>
    /// This method retrieves a list of members, filters out duplicates based on the Id property,
    /// and then prints the distinct members' details to the console.
    /// </remarks>
    public static void DistinctByPrimaryKey()
    {

        PrintCyan();

        var distinctList = MockedData.MembersList3()
            .DistinctBy(member => new
            {
                member.Id
            })
            .ToList();

        MemberHeader();

        foreach (var (index, item) in distinctList.Index())
        {
            Console.WriteLine($"{index,-7}{item.Id,-10}{item.FirstName,-10}{item.SurName}");
        }
    }

    /// <summary>
    /// Filters a list of members to include only distinct entries based on their address properties.
    /// </summary>
    /// <remarks>
    /// The distinct criteria are based on the combination of the following address properties:
    /// <list type="bullet">
    /// <item><description><see cref="Address.Id"/></description></item>
    /// <item><description><see cref="Address.Street"/></description></item>
    /// <item><description><see cref="Address.City"/></description></item>
    /// <item><description><see cref="Address.State"/></description></item>
    /// </list>
    /// </remarks>
    public static void DistinctByAddress()
    {

        PrintCyan();

        var distinctList = MockedData.MembersList4()
            .DistinctBy(member => new
            {
                member.Address.Id,
                member.Address.Street,
                member.Address.City,
                member.Address.State

            })
            .ToList();

        MemberHeader();

        foreach (var (index, item) in distinctList.Index())
        {
            Console.WriteLine($"{index,-7}{item.Id,-10}{item.FirstName,-10}{item.SurName}");
        }
    }
}