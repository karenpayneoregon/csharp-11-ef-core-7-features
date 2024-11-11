namespace DistinctByApp.Models;
/// <summary>
/// Represents a movie with properties for identification, name, release year, and rating.
/// </summary>
public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Released { get; set; }
    public int Rating { get; set; }
    public override string ToString() => Name;
}


