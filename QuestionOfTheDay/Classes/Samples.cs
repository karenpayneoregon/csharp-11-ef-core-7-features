using Bogus;
using QuestionOfTheDay.Extensions;
using QuestionOfTheDay.Models;
using static System.Globalization.DateTimeFormatInfo;

namespace QuestionOfTheDay.Classes;
internal class Samples
{
    public static string[] MonthNames => CurrentInfo!.MonthNames[..^1];
    public static string[] DayNames => CurrentInfo!.DayNames;

    public static void JoinWithSample()
    {
        var faker = new Faker();
        List<string> randomNames = Enumerable.Range(1, 7)
            .Select(_ => faker.Name.FirstName())
            .ToList();

        Console.WriteLine($" {DayNames.JoinWithLastSeparator()}");
        Console.WriteLine($" {randomNames.JoinWithLastSeparator1(" plus ")}");
    }

    private static void GroupBySample()
    {
        List<GroupMember> groups = MemberOperations.GetDuplicateActiveMembers(MemberOperations.MembersList());



        foreach (GroupMember groupMember in groups)
        {
            AnsiConsole.MarkupLine($"[cyan]{groupMember}[/]");
            foreach (Member member in groupMember.Lists)
            {
                Console.WriteLine($"\t{member.Id,-3}{member.Active}");
            }
        }
    }

    private static void DistinctBySeveralProperties()
    {
        var distinctByFirstLastNames = MemberOperations.MembersList()
            .DistinctBy(member => new
            {
                member.FirstName,
                member.SurName
            })
            .ToList();

        foreach (var member in distinctByFirstLastNames)
        {
            Console.WriteLine($"{member.Id,-4}{member.FirstName,-10}{member.SurName}");
        }
    }

    private static void Stash()
    {
        string sentence = "Hello    World  nice to be   here      ";
        Console.WriteLine($"'{sentence}'");
        Console.WriteLine($"'{sentence.RemoveExtraSpaces().TrimLastCharacter()}'");
        Console.WriteLine($"'{sentence.RemoveExtraSpaces().ReplaceLastOccurrence(" ", "!!!")}'");
    }

    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/api/system.string.replacelineendings?view=net-8.0
    /// </summary>
    public static void January25Challenge()
    {
        string lines =
            """
            January
            February
            March
            April
            May
            June
            July
            August
            September
            October
            November
            December
            """;

        var results = lines.ReplaceLineEndings("\n");
        Console.WriteLine("Place breakpoint here to validate");
    }
}
