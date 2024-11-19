using System.Diagnostics;

namespace ISetSamples.Classes;

public static class Extensions
{
    [DebuggerStepThrough]
    public static string SplitCamelCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        Span<char> result = stackalloc char[input.Length * 2];
        var resultIndex = 0;

        for (var index = 0; index < input.Length; index++)
        {
            var currentChar = input[index];

            if (index > 0 && char.IsUpper(currentChar))
            {
                result[resultIndex++] = ' ';
            }

            result[resultIndex++] = currentChar;
        }

        return result[..resultIndex].ToString();
    }


    /// <summary>
    /// Adds a range of items to the <see cref="SortedSet{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of items in the <see cref="SortedSet{T}"/>.</typeparam>
    /// <param name="source">The <see cref="SortedSet{T}"/> to add the items to.</param>
    /// <param name="items">The collection of items to add.</param>
    /// <returns><c>true</c> if all items were successfully added; otherwise, <c>false</c>.</returns>
    public static bool AddRange<T>(this SortedSet<T> source, IEnumerable<T> items)
    {
        bool allAdded = true;
        foreach (var item in items)
        {
            allAdded = allAdded & source.Add(item);
        }
        return allAdded;
    }


}
