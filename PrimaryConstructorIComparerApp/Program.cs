using PrimaryConstructorIComparerApp.Classes;
using PrimaryConstructorIComparerApp.Comparers;
using static PrimaryConstructorIComparerApp.Classes.SpectreConsoleHelpers;

namespace PrimaryConstructorIComparerApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        var students = Operations.Students();
        students.Sort(new StudentLastNameComparer());
        AnsiConsole.MarkupLine($"[cyan]{nameof(StudentLastNameComparer)}[/]");
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }

        Console.WriteLine();

        students.Sort(new StudentGradeComparer());
        AnsiConsole.MarkupLine($"[cyan]{nameof(StudentGradeComparer)}[/]");
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }

        ExitPrompt();
    }


}