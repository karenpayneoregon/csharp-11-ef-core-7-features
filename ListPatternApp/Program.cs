using System.Globalization;
using ListPatternApp.Classes;

namespace ListPatternApp;

internal partial class Program
{

    static void Main(string[] args)
    {
        BankTransactions();
        ValidatingLinesInTextFile();
        StringArrayMatchFirstThreeAndLastElement1();
        StringArrayMatchFirstThreeAndLastElement2();
        StringArrayMatchFirstThreeElements();
        IntegerArrayMisMatchFirstThreeElements();
        IntegerArrayMatchFirstThreeElements();


        Console.ReadLine();
    }

    /// <summary>
    /// Took a conceptual example from Microsoft which a novice coder would have trouble
    /// putting together and made one that provides a functional code sample
    ///
    /// This example takes a list of string array, where each element is one field in the row.
    /// The switch expression keys on the second field, which determines the kind of transaction,
    /// and the number of remaining columns. Each row ensures the data is in the correct format.
    /// The discard pattern (_) skips the first field, with the date of the transaction.
    /// The second field matches the type of transaction. Remaining element matches skip
    /// to the field with the amount. The final match uses the var pattern to capture the string
    /// representation of the amount. The expression calculates the amount to add or subtract from the balance.
    ///
    /// Karen's note, concerning creating a model for the data, recommend using a DateOnly for the first column
    /// which would be done with DateOnly.Parse(...) where ... is obtained by using string.Split(',')
    ///  </summary>
    /// <remarks>
    /// https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching#list-patterns
    /// </remarks>
    private static void BankTransactions()
    {
        Print();

        // local method
        List<string[]> ReadTransFromFile()
        {
            var items = new List<string[]>();
            var lines = File.ReadAllLines("Transactions.txt");
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                items.Add(parts);
            }

            return items;
        }

        List<string[]> records = ReadTransFromFile();
        decimal balance = 0m;
        foreach (string[] transaction in records)
        {
            balance += transaction switch
            {
                [_, "DEPOSIT" or "deposit", _, var amount] => decimal.Parse(amount),
                [_, "WITHDRAWAL", .., var amount] => -decimal.Parse(amount),
                [_, "INTEREST", var amount] => decimal.Parse(amount),
                [_, "FEE", var fee] => -decimal.Parse(fee),
                /*
                 * If transaction type is not recognized throw an exception. In this case
                 * I setup one line with deposit lowercase so we don't throw.
                 */
                _ => throw new InvalidOperationException(
                    $"Record {string.Join(", ", transaction)} is invalid"),
            };

            if (balance < 1000)
            {
                AnsiConsole.MarkupLine($"[cyan]Record:[/] {string.Join(", ", transaction),-50} [white on red]Balance[/] {balance:C}");
            }
            else
            {
                AnsiConsole.MarkupLine($"[cyan]Record:[/] {string.Join(", ", transaction),-50} [yellow]Balance[/] {balance:C}");
            }
            
        }

        Console.WriteLine();

    }


    private static void ValidatingLinesInTextFile()
    {
        Print();

        string[] lines = File.ReadAllLines("Sample1.txt")
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToArray();

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts is [ _, _, "10" or "50", "True" or "False" or "true" or "false" ])
            {
                AnsiConsole.MarkupLine($"      [cyan]Match[/] [[{string.Join(",", parts)}]]");
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]Not a match[/] [[{string.Join(",", parts)}]]");
            }
        }

        Console.WriteLine();

    }
    private static void ValidatingLines()
    {
        Print();

        string[] data = { "Mike,Jones,10,True", "Jane,Adams,A,True", "Karen,Smith,10,true", "Anne,Smith,50,false" };

        string[] lines = data
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToArray();

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts is [_, _, "10" or "50", "True" or "False" or "true" or "false"])
            {
                Console.WriteLine($"      Match {string.Join(",", parts)}");
            }
            else
            {
                Console.WriteLine($"Not a match {string.Join(",", parts)}");
            }
        }

        Console.WriteLine();

    }

    /// <summary>
    /// Jagged match
    /// </summary>
    private static void StringArrayMatchFirstThreeAndLastElement1()
    {
        Print();

        var months = DateTimeFormatInfo.CurrentInfo.MonthNames[..^1].ToArray();
            

        // if 1st three elements are January February March and last element is December continue
        if (months is ["January", "February", "March", _ , _ , _ , _ , _ , _ , _ , _ , "December"])
        {
            Console.WriteLine("Match");
        }
        else
        {
            Console.WriteLine("Failed");
        }

        Console.WriteLine();

    }

    /// <summary>
    /// Same as above but what about case sensitivity? we need to OR
    /// </summary>
    private static void StringArrayMatchFirstThreeAndLastElement2()
    {

        Print();

        string[] months =
        {
            "january", "February", "March", "April", "May", "June", "July", 
            "August", "September", "October", "November", "December"
        };

        // if 1st three elements are January February March and last element is December continue
        if (months is ["January" or "january", "February", "March", _, _, _, _, _, _, _, _, "December"])
        {
            Console.WriteLine("Match");
        }
        else
        {
            Console.WriteLine("Failed");
        }

        Console.WriteLine();

    }

    /// <summary>
    /// Expect first three elements to be January February March and then display remaining month names in monthNames
    /// string array
    /// </summary>
    private static void StringArrayMatchFirstThreeElements()
    {
            
        Print();

        var months = DateTimeFormatInfo.CurrentInfo.MonthNames[..^1].ToArray();
        if (months is ["January", "February", "March", .. var monthNames])
        {
            Console.WriteLine(string.Join(",", monthNames));
        }
        else
        {
            Console.WriteLine("Failed");
        }

        Console.WriteLine();

    }

    /// <summary>
    /// Expected first three elements to be 1 2 4 but were 1 2 3
    /// </summary>
    private static void IntegerArrayMisMatchFirstThreeElements()
    {
            
        Print();

        var list1 = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        if (list1 is [1, 2, 4, .. var values])
        {
            Console.WriteLine(string.Join(",", values));
        }
        else
        {
            AnsiConsole.MarkupLine("Failed - [yellow]this is correct[/]");
        }

        Console.WriteLine();

    }

    /// <summary>
    /// Match first three elements 1 2 3 and then display the remaining elements in value variable
    /// </summary>
    private static void IntegerArrayMatchFirstThreeElements()
    {
            
        Print();

        var list1 = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        if (list1 is [1, 2, 3, .. var values])
        {
            Console.WriteLine(string.Join(",", values));
        }
        else
        {
            Console.WriteLine("Failed");
        }

        Console.WriteLine();

    }
}