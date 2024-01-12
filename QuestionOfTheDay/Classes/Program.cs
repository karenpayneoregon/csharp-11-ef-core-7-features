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
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Fill);
    }

    private static void January12Question()
    {

        var array = new[] { 1, 2, 3, 4, 5 };

        var firstThree1 = array[..3];
        var lastThree1 = array[^3..];

        var firstThree2 = array.Take(3).ToArray();
        var lastThree2 = array.TakeLast(3).ToArray();

    }
    private static void January12Extra(int[] array)
    {
        Console.WriteLine(ObjectDumper.Dump(array.Get()));
    }
}
