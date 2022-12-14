using NumericMethodsApp.Classes;

namespace NumericMethodsApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]Number methods[/]");
        StandardExamples();
        Console.ReadLine();
    }
    public static void StandardExamples()
    {
        double dCost = 12.3;
        Console.WriteLine($"      double.IsInteger({dCost}) > {double.IsInteger(dCost).ToYesNo()}");
        dCost = 12;
        Console.WriteLine($"        double.IsInteger({dCost}) > {double.IsInteger(dCost).ToYesNo()}");

        float fCost = 12.4f;
        Console.WriteLine($"       float.IsInteger({fCost}) > {float.IsInteger(fCost).ToYesNo()}");
        fCost = 12;
        Console.WriteLine($"         float.IsInteger({fCost}) > {float.IsInteger(fCost).ToYesNo()}");

        decimal decCost = 3;
        Console.WriteLine($"     decimal.IsOddInteger({decCost}) > {decimal.IsOddInteger(decCost).ToYesNo()}");
        Console.WriteLine($"        decimal.IsInteger({decCost}) > {decimal.IsEvenInteger(decCost).ToYesNo()}");
    }
}