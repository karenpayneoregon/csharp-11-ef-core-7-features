using GenericMath12.Classes;
// ReSharper disable SpecifyACultureInStringConversionExplicitly

namespace GenericMath12;

    internal partial class Program
    {
        private static void Main()
        {
            Table CreateTable() => new Table()
                    .AddColumn("")
                    .AddColumn("")
                    .Alignment(Justify.Left)
                    .HideHeaders()
                    .BorderColor(Color.Cyan1).Caption("[grey]Press ENTER to exit[/]");

            const decimal decimalValue = 123_456_789.43534m;
            const double doubleValue = 123_456_789.43534;
            const int places = 3;
            const string color = "orchid1";


            var table = CreateTable();
            table.AddRow($"[{color}]decimal C{places}[/]", decimalValue.Truncate(places).ToCurrency(places))
                 .AddRow($"[{color}]double  C{places}[/]", doubleValue.Truncate(places).ToCurrency(places))
                 .AddRow($"[{color}]fractional part as decimal[/]", doubleValue.GetFractionalPart(places).ToString())
                 .AddRow($"[{color}]fractional part as int[/]", doubleValue.GetFractionalPartInt(places).ToString());

            AnsiConsole.Write(table);
            Console.ReadLine();
        }
    }