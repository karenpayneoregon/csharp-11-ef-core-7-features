using DistinctByApp.Classes;

namespace DistinctByApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        Samples.DistinctByFirstLastNames();
        Samples.DistinctByFirstLastNameAndActive();

        NextResults();

        Samples.DistinctByPrimaryKey();
        Samples.DistinctByAddress();

        NextResults();

        Samples.GroupMoviesOnReleased();
        Samples.DistinctByMovieReleasedYear();

        AnsiConsole.MarkupLine("[bold blue]End of samples[/]");
        Console.ReadLine();
    }
}