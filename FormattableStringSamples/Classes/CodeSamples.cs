using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using static System.Diagnostics.CodeAnalysis.StringSyntaxAttribute;

namespace FormattableStringSamples.Classes;
internal static class CodeSamples
{
    public static void FormatDates([StringSyntax(DateOnlyFormat)] string style, params DateOnly[] dates)
    {
        foreach (var argument in dates)
        {
            Console.WriteLine(argument.ToString(style));
        }
    }



    public static void TestJson([StringSyntax(Json)] JsonSerializerOptions format, string data)
    {

    }

    public static void ReadJson(string json)
    {

    }

    public static void DoSomeXml(string value)
    {

    }

}

