using System.Runtime.CompilerServices;


// ReSharper disable once CheckNamespace
namespace IndexMonths
{
    internal partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            AnsiConsole.MarkupLine("");
            Console.Title = "Month indexing";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        }
        
        /// <summary>
        /// Creates and configures a new table for displaying month indexing details.
        /// </summary>
        /// <returns>
        /// A <see cref="Table"/> instance with predefined columns and styling for displaying month names, indices, and ranges.
        /// </returns>
        private static Table CreateTable()
        {
            return new Table()
                .RoundedBorder().BorderColor(Color.LightSlateGrey)
                .AddColumn("[b]Name[/]")
                .AddColumn("[b]Index[/]")
                .AddColumn("[b]Start Index[/]")
                .AddColumn("[b]End Index[/]")
                .Alignment(Justify.Center)
                .Title("[white on chartreuse3]Month indexing[/]");
        }
        private static void Render(Rule rule)
        {
            AnsiConsole.Write(rule);
            AnsiConsole.WriteLine();
        }

        /// <summary>
        /// Displays a prompt to the user, instructing them to press a key to exit the application.
        /// </summary>
        private static void ExitPrompt()
        {

            Render(new Rule($"[green1]Press a key to exit[/]")
                .RuleStyle(Style.Parse("white"))
                .Centered());

            Console.ReadLine();
        }
    }
}
