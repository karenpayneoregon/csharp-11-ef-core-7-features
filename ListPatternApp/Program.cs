using System.Globalization;
using ListPatternApp.Classes;

namespace ListPatternApp;

internal partial class Program
{

    static void Main(string[] args)
    {
        //ValidatingLinesFromRawStringLiteral();
        //BankTransactions();
        //var lines = MockedLinesFromFile();
        ValidatingLinesInTextFile1();
        Console.WriteLine();
        ValidatingLinesInTextFile2();
        Console.WriteLine();
        ValidatingLinesInTextFile3();
        //MicrosoftSample();
        //StringArrayMatchFirstThreeAndLastElement1();
        //StringArrayMatchFirstThreeAndLastElement2();
        //StringArrayMatchFirstThreeElements();
        //IntegerArrayMisMatchFirstThreeElements();
        //IntegerArrayMatchFirstThreeElements();

        var parts = MockedLinesFromFile()
            .Where(x=> !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Split(','));


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
        static decimal GetDecimal(string sender)
        {
            if (decimal.TryParse(sender, out var value))
            {
                return value;
            }
            else
            {
                return 0;
            }
        }
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
                [_, "DEPOSIT" or "deposit", _, var amount] => GetDecimal(amount),
                [_, "WITHDRAWAL", .., var amount] => -GetDecimal(amount),
                [_, "INTEREST", var amount] => GetDecimal(amount),
                [_, "FEE", .., var fee] => -GetDecimal(fee),
                /*
                 * If transaction type is not recognized throw an exception. In this case
                 * I setup one line with deposit lowercase so we don't throw.
                 */
                _ => throw new InvalidOperationException(
                    $"Record {string.Join(", ", transaction)} is invalid"),
            };

            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
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


    private static IEnumerable<string> MockedLinesFromFile() =>
        """
            Mike,Jones,10,True
            Jane,Adams,A,True
            Karen,Smith,10,true

            Mike,Adams,50,false
            """
            .Split(Environment.NewLine);

    private static string[] fileA() => 
        """
        Bankov, Peter  
        Holm, Michael  
        Garcia, Hugo  
        Potra, Cristina  
        Noriega, Fabricio  
        Aw, Kam Foo  
        Beebe, Ann  
        Toyoshima, Tim  
        Guy, Wey Yuan  
        Garcia, Debra
        """.Split(Environment.CommandLine);

    private static string[] fileB() =>
        """
            Liu, Jinghao  
            Bankov, Peter  
            Holm, Michael  
            Garcia, Hugo  
            Beebe, Ann  
            Gilchrist, Beth  
            Myrcha, Jacek  
            Giakoumakis, Leo  
            McLin, Nkenge  
            El Yassir, Mehdi
            """.Split(Environment.CommandLine);

    // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/how-to-split-a-file-into-many-files-by-using-groups-linq
    private static void MicrosoftSample()
    {
        var mergeQuery = fileA().Union(fileB());

        // Group the names by the first letter in the last name.  
        var groupQuery = from name in mergeQuery
            let n = name.Split(',')
            group name by n[0][0] into g
            orderby g.Key
            select g;

        foreach (var g in groupQuery)
        {
            Console.WriteLine(g.Key);
            foreach (var item in g)
            {
                var data = item.Split(Environment.NewLine);
                foreach (var dataItem in data)
                {
                    Console.WriteLine($"{dataItem,30}");
                }
            }
        }
    }

    private static void ValidatingLinesInTextFile1()
    {
        Print();

        string[] lines = MockedLinesFromFile().Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

        foreach (string line in lines)
        {
            var parts = line.Split(',');
            AnsiConsole.MarkupLine(parts is [ _ , _ , "10" or "50", "True" or "False" or "true" or "false"]
                ? $"      [cyan]Match[/] [[{string.Join(",", parts)}]]"
                : $"[red]Not a match[/] [[{string.Join(",", parts)}]]");
        }
    }

    private static void ValidatingLinesInTextFile2()
    {
        Print();

        string[] lines = MockedLinesFromFile().Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
        string[][] parts = lines.Select(x => x.Split(',')).ToArray();

        foreach (string[] part in parts)
        {
            AnsiConsole.MarkupLine(part is [ _ , _ , "10" or "50", "True" or "False" or "true" or "false"]
                ? $"      [cyan]Match[/] [[{string.Join(",", part)}]]"
                : $"[red]Not a match[/] [[{string.Join(",", part)}]]");
        }
    }

    private static void ValidatingLinesInTextFile3()
    {
        Print();

        var parts = MockedLinesFromFile()
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Split(','));

        foreach (string[] part in parts)
        {
            AnsiConsole.MarkupLine(part is [_, _, "10" or "50", "True" or "False" or "true" or "false"]
                ? $"      [cyan]Match[/] [[{string.Join(",", part)}]]"
                : $"[red]Not a match[/] [[{string.Join(",", part)}]]");
        }

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
        if (months is ["January" or "january", "February", "March", _ , _ , _ , _ , _ , _ , _ , _ , "December"])
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