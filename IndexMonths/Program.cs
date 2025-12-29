using System.Text;
using IndexMonths.Classes;

namespace IndexMonths
{
    internal partial class Program
    {
        static void Main(string[] args)
        {

            var monthContainer = Helpers.RangeDetails(Helpers.MonthNames());
            var table = CreateTable();
            monthContainer.ForEach(x => table.AddRow(x.ItemArray));
            
            AnsiConsole.Write(table);

            ExitPrompt();
        }
    }
}