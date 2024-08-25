using FormattableSamples.Classes;

namespace FormattableSamples;

internal partial class Program
{
    static void Main(string[] args)
    {
        Samples.CreateAndViewPeople();
        Samples.TheWeekend();
        Samples.UpdateProperties();
        Samples.SqlStatementExample();

        SpectreConsoleHelpers.ExitPrompt();
    }
}