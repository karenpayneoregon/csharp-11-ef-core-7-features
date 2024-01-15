using System.Numerics;

namespace QuestionOfTheDay.Extensions;


public static class ArrayExtensions
{
    #region Concat arrays (I decided to call them Merege, feel free to rename if so desire)
    public static T[] Merge1<T>(this T[] front, T[] back) where T : INumber<T>
        => front.Concat(back).ToArray();

    public static T[] Merge2<T>(this T[] front, T[] back) where T : INumber<T>
        => [ .. front, .. back];
    #endregion
}
