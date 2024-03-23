using System.Numerics;
// ReSharper disable InconsistentNaming

namespace QuestionOfTheDay.Extensions;


//public static class ArrayExtensions
//{
//    public static T[] Merge1<T>(this T[] container, T[] back) where T : INumber<T>
//        => container.Concat(back).ToArray();

//    public static T[] Merge2<T>(this T[] container, T[] back) where T : INumber<T>
//        => [ .. container, .. back];

//}

public static class GenericINumberExtensions
{
    public static T[] Merge<T>(this T[] container, T[] T1) where T : INumber<T>
        => [.. container, .. T1];

    public static T[] Merge<T>(this T[] container, T[] T1, T[] T2) where T : INumber<T>
        => [.. container, .. T1, .. T2];

    public static T[] Merge<T>(this T[] container, T[] T1, T[] T2, T[] T3) where T : INumber<T>
        => [.. container, .. T1, .. T2, .. T3];

    public static T[] Merge<T>(this T[] container, T[] T1, T[] T2, T[] T3, T[] T4) where T : INumber<T>
        => [.. container, .. T1, .. T2, .. T3, .. T4];

    public static List<T> Merge<T>(this List<T> container, T[] T1, T[] T2) where T : INumber<T>
        => [.. container, .. T1, .. T2];

    public static List<T> Merge<T>(this List<T> container, T[] T1, T[] T2, T[] T3) where T : INumber<T>
        => [.. container, .. T1, .. T2, .. T3];
}
