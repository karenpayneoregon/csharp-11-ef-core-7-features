using FormattableSamples.Classes;

namespace FormattableSamples;

internal partial class Program
{
    static void Main(string[] args)
    {
        Samples.CreateAndViewPeople();
        Samples.TheWeekend1();
        Samples.UpdateProperties();
        Samples.SqlStatementExample();
        Samples.DateTimeCulture();
        Samples.VersionFormat();

        SpectreConsoleHelpers.ExitPrompt();
    }
}