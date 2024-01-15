using QuestionOfTheDay.Extensions;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace QuestionOfTheDay;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = $"Question of the day for '{DateTime.Now:D}'";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    private static void January12Question()
    {

        var array = new[] { 1, 2, 3, 4, 5 };

        var firstThree1 = array[..3];
        var lastThree1 = array[^3..];

        var firstThree2 = array.Take(3).ToArray();
        var lastThree2 = array.TakeLast(3).ToArray();

        January12Extra(array);

    }
    private static void January12Extra(int[] array)
    {
        Console.WriteLine(ObjectDumper.Dump(array.Get()));
    }

    private static void January15Question()
    {
        var arr1 = new[] { 1, 2, 3, 4, 5, 0 };
        var arr2 = new[] { 6, 7, 8, 9, 0 };
        var array1 = arr1.Merge1(arr2);

        Console.WriteLine(string.Join(",", array1));
        var array2 = arr1.Merge2(arr2);
        Console.WriteLine(string.Join(",", array2));
    }
}
