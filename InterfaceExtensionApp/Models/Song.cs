using System.Diagnostics.CodeAnalysis;

namespace InterfaceExtensionApp.Models;
public class Song : IParsable<Song>
{
    public string Name { get; set; }
    public string Artist { get; set; }
    public int LengthInSeconds { get; set; }

    private Song(string name, string artist, int lengthInSeconds)
    {
        Name = name;
        Artist = artist;
        LengthInSeconds = lengthInSeconds;
    }

    public static Song Parse(string s, IFormatProvider? provider)
    {
        string[] songPortions = s.Split(['|']);

        if (songPortions.Length != 3)
        {
            throw new OverflowException("Expect format: Name|Artist|LengthInSeconds");
        }

        return new Song(songPortions[0], songPortions[1], int.Parse(songPortions[2]));
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Song result)
    {
        result = null;
        if (s == null)
        {
            return false;
        }

        try
        {
            result = Parse(s, provider);
            return true;
        }
        catch { return false; }
    }
}