using ConnectingToDatabase.Data;

namespace ConnectingToDatabase
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {
            AnsiConsole.MarkupLine("[yellow]Connecting[/]");

            await using var context = new Context();
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            Console.WriteLine(context.Categories.Count());
            
            Console.WriteLine();
            AnsiConsole.MarkupLine("[cyan]Done[/]");

            Console.ReadLine();
        }
    }
}