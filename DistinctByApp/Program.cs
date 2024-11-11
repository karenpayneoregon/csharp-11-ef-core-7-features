using DistinctByApp.Classes;

namespace DistinctByApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        Samples.DistinctByFirstLastNames();
        Samples.DistinctByFirstLastNameAndActive();
        Samples.DistinctByPrimaryKey();
        Samples.DistinctByAddress();

        NextResults();

        Samples.GroupMoviesOnReleased();
        Samples.DistinctByMovieReleasedYear();

        Console.ReadLine();
    }
}