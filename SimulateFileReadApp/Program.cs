namespace SimulateFileReadApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        int[] array =  [ 1, 2, 3, 4, 5, 6, 7, 8, 9 ];

        if (array is [1, >= 2, .. var values, 9])
            Console.WriteLine(string.Join(",", values));

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
}

static class Extensions
{
    public static string ToYesNo(this bool value) => value ? "Yes" : "No";
}

