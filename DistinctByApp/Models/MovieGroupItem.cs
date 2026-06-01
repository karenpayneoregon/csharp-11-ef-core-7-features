namespace DistinctByApp.Models;

/// <summary>
/// Represents an item in a group of movies, categorized by whether the movie's name starts with "The" and its rating.
/// </summary>
public class MovieGroupItem(bool startsWithThe, int rating)
{
    public bool StartsWithThe { get; } = startsWithThe;
    public int Rating { get; } = rating;
}