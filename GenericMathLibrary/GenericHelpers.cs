using System.Numerics;

namespace GenericMathLibrary;

public class GenericHelpers
{
    public static T Add<T>(T left, T right) where T : INumber<T> => left + right;
    public static T AddAll<T>(Span<T> values) where T : INumber<T> => values switch
    {
        [] => T.Zero,
        [var first, .. var rest] => first + AddAll<T>(rest)
    };

    public static T AddAll<T>(T[] sender) where T : INumber<T>
    {
        T result = T.Zero;
        foreach (T item in sender) { result += item; }
        return result;
    }

    public static List<T> CreateList<T>(int numberOfItems) where T : new()
    {
        var result = new List<T>(numberOfItems);
        for (int index = 0; index < numberOfItems; index++)
        {
            result.Add(new T());
        }

        return result;
    }
}
