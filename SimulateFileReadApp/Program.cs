using static System.Globalization.DateTimeFormatInfo;

namespace SimulateFileReadApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine();
        int[] array =  [ 1, 2, 3, 4, 5, 6, 7, 8, 9 ];

        //if (array is [1, >= 2, .. var values, 9])
        //    Console.WriteLine(string.Join(",", values));


        //LinesSample1();
        Console.ReadLine();
    }

    private static void LinesSample()
    {
        string[][] lines =
            """
                    Mike,Jones,10,True,1

                    Jane,Adams,30,True,2

                    Karen,Smith,10,true,3

                    Jean,Smith,50,false,4

                    """
                .Split(Environment.NewLine)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Split(','))
                .ToArray();

        foreach (string[] parts in lines)
        {
            AnsiConsole.MarkupLine(parts is [_, _, "10" or "50", "True" or "False" or "true" or "false", _]
                ? $"      [cyan]Match[/] [[{string.Join(",", parts)}]]"
                : $"[red]Not a match[/] [[{string.Join(",", parts)}]]");
        }
    }

    /// <summary>
    /// Processes a multi-line string containing comma-separated values, filters out empty lines,
    /// splits each line into parts, and evaluates whether each line matches a specific pattern.
    /// </summary>
    /// <remarks>
    /// The method uses LINQ to split the input string into lines, remove empty or whitespace-only lines,
    /// and then split each line into an array of strings. It checks if each line matches a specific pattern
    /// (e.g., containing "Male" or "Female" as the third element) and outputs the result using AnsiConsole.
    /// </remarks>
    private static void LinesSample1()
    {

        string[][] lines =
            """
                John,Adams,Male,1985-01-15,123-45-6789

                Emily,Brown,Female,1990-02-20,234-56-7890
                Michael,Clark,Male,1982-03-25,345-67-8901

                Sarah,Davis,Female,1995-04-30,456-78-9012
                David,Evans,Male,1988-05-10,567-89-0123

                Laura,Foster,Female,1992-06-15,678-90-1234
                James,Green,male,1983-07-20,789-01-2345

                Olivia,Harris,Female,1996-08-25,890-12-3456
                William,Johnson,Mahe,1987-09-30

                Sophia,King,female,1991-10-05,012-34-5678

                """
                .Split(Environment.NewLine)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Split(','))
                .ToArray();

        foreach (string[] parts in lines)
        {
            if (parts.Length == 5)
            {
                AnsiConsole.MarkupLine(parts is [_, _, "Male" or "Female" or "male" or "female", _, var ssn]
                    ? $"      [cyan]Match[/] [[{string.Join(",", parts)}]] -> [yellow]{ssn}[/]"
                    : $"[red]Not a match[/] [[{string.Join(",", parts)}]]");
            }
            else
            {
                AnsiConsole.MarkupLine($"      [red]Invalid line[/] [[{string.Join(",", parts)}]]");
            }
        }

    }
}

static class Extensions
{
    public static string ToYesNo(this bool value) => value ? "Yes" : "No";
}

