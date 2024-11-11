namespace DistinctByApp.Models;
/// <summary>
/// Represents a movie item with properties indicating whether the movie's name starts with "The" and its rating.
/// </summary>
public class MovieItem
{
    public bool StartsWithThe { get; }
    public int Rating { get; }

    public MovieItem(bool startsWithThe, int rating)
    {
        StartsWithThe = startsWithThe;
        Rating = rating;
    }
}