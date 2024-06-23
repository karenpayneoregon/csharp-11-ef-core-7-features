using NumericMethodsApp.Classes;

namespace NumericMethodsApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]Number methods[/]");

        for (int index = 0; index < 12; index++)
        {
            //Console.WriteLine(int.IsEvenInteger(index) ? $"E {index}" : $"O {index}");
        }


        Console.WriteLine($"         Max between 23 and 22 => {int.MaxMagnitude(23, 22)}");
        Console.WriteLine($"         Min between 23 and 22 => {int.MinMagnitude(23, 22)}");
        Console.WriteLine($"                  Is -8 positive? {int.IsPositive(-8)}");
        Console.WriteLine($"                   Is 8 positive? {int.IsPositive(8)}");
        Console.WriteLine($"                      Is -7 even? {int.IsEvenInteger(-7)}");
        Console.WriteLine($"                      Is -8 even? {int.IsEvenInteger(8)}");
        Console.WriteLine($"                       Is -7 odd? {int.IsOddInteger(-7)}");
        Console.WriteLine($"                        Is 8 odd? {int.IsOddInteger(8)}");
        Console.WriteLine($"Is Hour {DateTime.Now.Hour} odd? {int.IsOddInteger(DateTime.Now.Hour)}");
        
      

        //StandardExamples();
        Console.ReadLine();
    }
    // create a customer class  with Id, FirstName, LastName, and birthDate properties without specifying the namespace


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