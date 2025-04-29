using PrimaryConstructorIComparerApp.Classes;
using PrimaryConstructorIComparerApp.Comparers;

namespace PrimaryConstructorIComparerApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        var students = Operations.Students();

        students.Sort(new LastNameComparer());
        AnsiConsole.MarkupLine($"[cyan]{nameof(LastNameComparer)}[/]");

        foreach (var student in students)
        {
            Console.WriteLine(student);
        }

        Console.WriteLine();

        students.Sort(new GradeComparer());
        AnsiConsole.MarkupLine($"[cyan]{nameof(GradeComparer)}[/]");

        foreach (var student in students)
        {
            Console.WriteLine(student);
        }

        ExitPrompt();
    }


}