using QuestionOfTheDay.Models;
using static System.Globalization.DateTimeFormatInfo;

namespace QuestionOfTheDay.Classes;
internal class Samples
{
    public static string[] MonthNames => CurrentInfo!.MonthNames[..^1];
    public static string[] DayNames => CurrentInfo!.DayNames;

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
    }s
}
