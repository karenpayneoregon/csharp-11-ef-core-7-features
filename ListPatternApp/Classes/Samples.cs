
using System.Text.Json;

namespace ListPatternApp.Classes;

internal class Samples
{
    public static void IntegerListMatch()
    {

        List<List<int>> list =
        [
            [1, 4], [1, 2, 3], [1, 2, 3, 4], [0, 2, 3, 4], [1, 2, 3, 5 ,4],
        ];

        Console.WriteLine("Data");


        foreach (var sublist in list)
        {
            Console.WriteLine($"[{string.Join(", ", sublist)}]");
        }

        Console.WriteLine();

        foreach (var (index, item) in list.Index())
        {
            Console.WriteLine($"{index,-2} is match    {(item is [1, 2, 3, .., 4] ? "Match" : "Not a match")}");
        }

    }

}