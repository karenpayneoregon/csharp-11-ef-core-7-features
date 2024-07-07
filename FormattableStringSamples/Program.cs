using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json;
using FormattableStringSamples.Classes;
using FormattableStringSamples.Models;

namespace FormattableStringSamples;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]Hello[/]");
        

        CodeSamples.FormatDates("MM/dd/yyyy", [new DateOnly(2000, 1, 1), new DateOnly(1999, 12, 9)]);

        
        //PersonFormat();
        //DayOfWeekExample();
        //InsertStatementExample();


        Console.ReadLine();
    }

    [StringSyntax(StringSyntaxAttribute.DateOnlyFormat)]
    public static DateOnly Demo { get; set; }
}
