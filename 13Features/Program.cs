
namespace _13Features;

using static System.Globalization.DateTimeFormatInfo;
internal partial class Program
{
    static void Main(string[] args)
    {
        

        Console.ReadLine();

    }

    public static List<string> Months => CurrentInfo.MonthNames[..^1].ToList();
}

