
using System.Xml.Linq;

namespace QuestionOfTheDay.Extensions;


public static class SequenceExtensions
{


    public static int[] Missing1A(this int[] sequence, int start = 1)
    {
        return Enumerable
            .Range(start, sequence[^1])
            .Except(sequence)
            .ToArray();
    }

    /// <summary>
    /// Contribution from Twitter @thefactorygrows
    /// </summary>
    /// <example>
    /// <code>
    /// int[] array2 = { 1, 3, 6, 7, 8, 10, 11, 4 };
    /// var results2 = array.MissingWithMax();
    /// Console.WriteLine($"Method 2 Result : {ObjectDumper.Dump(string.Join(",", results2))}");
    /// Console.WriteLine($"Method 2 After  : {ObjectDumper.Dump(string.Join(",", array2))}");
    /// </code>
    /// </example>
    public static int[] MissingWithMax(this int[] sequence, int start = 1)
    {
        return Enumerable
            .Range(start, sequence.Max())
            .Except(sequence)
            .ToArray();
    }

    public static int[] Missing(this int[] sequence, int start = 1)
    {
        Array.Sort(sequence);
        return Enumerable

            .Range(start, sequence[^1])

            .Except(sequence)
            .ToArray();
    }



    public static bool HasNull(this int[] sender)
    {
        return sender.Any(t => t == null);
    }

    /// <summary>
    /// Determine if the sequence has missing elements
    /// </summary>
    /// <param name="sequence">int array</param>
    /// <returns>true if missing elements, false if no missing elements</returns>
    public static bool IsSequenceBroken(this int[] sequence)
    {
        return sequence.Sort().Zip(sequence.Skip(1), (valueLeft, valueRight)
            => valueRight - valueLeft).Any(item => item != 1);
    }

    public static int[] Sort(this int[] sender)
    {
        Array.Sort(sender);
        return sender;
    }
}
