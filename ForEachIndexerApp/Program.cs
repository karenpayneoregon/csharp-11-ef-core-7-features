using System.Globalization;
using System.Runtime.InteropServices;
// ReSharper disable NotDisposedResource

namespace ForEachIndexerApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        List<string> list = [.. DateTimeFormatInfo.CurrentInfo.MonthNames[..^1]];

        //Marc Gravell
        Span<string> span = CollectionsMarshal.AsSpan(list);
        for (int i = 0; i < span.Length; i++)
        {
            var name = span[i]; // if useful multiple times
            Console.WriteLine($"{i,-3}{span[i]}");
        }

        AnsiConsole.MarkupLine("[yellow]----------------[/]");



        var listEnumerator = list.GetEnumerator();

        for (var index = 0; listEnumerator.MoveNext(); index++)
        {
            Console.WriteLine($"{index,-3}{listEnumerator.Current}");
        }


        AnsiConsole.MarkupLine("[yellow]----------------[/]");


        foreach (var (item, index) in list.Index())
        {
            Console.WriteLine($"{index,-3}{item}");
        }


        AnsiConsole.MarkupLine("[yellow]----------------[/]");

        foreach (var item in list.Select((value, Index) => new { Index, value }))
        {
            Console.WriteLine($"{item.Index,-3}{item.value}");
        }

        foreach (var (item, index) in list.Index())
        {
            
        }

        AnsiConsole.MarkupLine("[yellow]----------------[/]");

        foreach (var (value, index) in list.Select((v, i) => (value: v, index: i)))
        {
            Console.WriteLine($"{index,-3}{value}");
        }

        AnsiConsole.MarkupLine("[yellow]----------------[/]");

        list.ForEachWithIndex((item, index) => Console.WriteLine("{0,-3}{1}", index, item));

        Console.ReadLine();
    }
}
public static class IEnumerableExtensions
{
    public static IEnumerable<(T item, int index)> Index<T>(this IEnumerable<T> sender)
        => sender.Select((item, index) => (item, index));
}

public static class Extensions
{
    public static void ForEachWithIndex<T>(this IEnumerable<T> sender, Action<T, int> handler)
    {
        int idx = 0;
        foreach (T item in sender)
        {
            handler(item, idx++);
        }
    }

}