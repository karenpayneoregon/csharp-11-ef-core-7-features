namespace DistinctByApp.Models;

/// <summary>
/// Represents an item in a group of movies, categorized by whether the movie's name starts with "The" and its rating.
/// </summary>
public class MovieGroupItem
{
    public bool StartsWithThe { get; }
    public int Rating { get; }

    public MovieGroupItem(bool startsWithThe, int rating)
    {
        StartsWithThe = startsWithThe;
        Rating = rating;
    }
}