
namespace QuestionOfTheDay.Extensions;


public static class SequenceExtensions
{

    public static int[] Missing1(this int[] sequence, int start = 1)
    {
        return Enumerable
            .Range(start, sequence[^1])
            .Except(sequence)
            .ToArray();
    }

    public static int[] Missing2(this int[] sequence, int start = 1)
    {
        Array.Sort(sequence);
        return Enumerable
            .Range(start, sequence[^1])
            .Except(sequence)
            .ToArray();
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
