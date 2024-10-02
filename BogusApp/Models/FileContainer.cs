namespace BogusApp.Models;

public record FileContainer
{
    public string FileName { get; set; }
    public sealed override string ToString() => FileName;
}