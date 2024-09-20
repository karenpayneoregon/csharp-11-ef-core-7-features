using FormattableSamples.Classes;
using FormattableSamples.Models;
using System.Runtime.CompilerServices;

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
        
        Demo();

        SpectreConsoleHelpers.ExitPrompt();
    }

    /// <summary>
    /// https://stackoverflow.com/questions/79003815/how-to-extract-placeholders-in-a-string
    /// </summary>
    private static void Demo()
    {
        List<TemplateItem> items =
        [
            new() { Name = "Mike", Team = "Team A", Position = "Team lead" },
            new() { Name = "Karen", Team = "Team B", Position = "Developer" },
            new() { Name = "Sam", Team = "Team C", Position = "Developer" }
        ];

        var result = items.Select(ti => 
            CreateTemplate(ti.Name, ti.Team, ti.Position)).ToList();

        foreach (var item in result)
        {
            Console.WriteLine(item);
            Console.WriteLine();
        }
    }
    public static string CreateTemplate(string name, string team, string position) =>
        FormattableStringFactory
            .Create("""
                    My name is {0}
                    and I am working in the
                    {1}
                    team\\n as a {2}
                    """,
                name,
                team,
                position).ToString();
}