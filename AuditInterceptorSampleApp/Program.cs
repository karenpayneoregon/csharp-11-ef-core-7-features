using AuditInterceptorSampleApp.Classes;
using AuditInterceptorSampleApp.Data;
using AuditInterceptorSampleApp.Models;
using Azure;
using Microsoft.EntityFrameworkCore;
using static AuditInterceptorSampleApp.Classes.ExceptionHelpers;
using static AuditInterceptorSampleApp.Classes.SpectreConsoleHelpers;

namespace AuditInterceptorSampleApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        AnsiConsole.MarkupLine("[cyan]Creating database[/]");

        var (success, exception) = await DataOperations.CreateDatabaseAndPopulate();
        if (success)
        {
            AnsiConsole.MarkupLine("[cyan]Populating database[/]");
            var (verified, exception1) = await DataOperations.InitialCreateDatabase();
            if (verified)
            {
                AnsiConsole.MarkupLine("[cyan]Performing updates[/]");
                await DataOperations.UpdateRecords();
                AnsiConsole.MarkupLine("[cyan]Done, check out the log file under[/] [yellow]LogFiles[/] [cyan]from the app folder[/]");
                LineSeparator();
                Console.WriteLine();

                List<Book> books = await DataOperations.ReadBack();
                Table table = CreateTable();

                foreach (var book in books)
                {
                    table.AddRow(
                        book.Id.ToString(), 
                        book.Category.Description, 
                        book.Title, 
                        book.Price.ToString("C"));
                }

                AnsiConsole.Write(table);

            }
            else
            {
                ColorStandard(exception);
            }
        }
        else
        {
            AnsiConsole.WriteException(exception);
        }

        ExitPrompt();
    }

    public static Table CreateTable()
    {
        var table = new Table()
            .RoundedBorder()
            .AddColumn("[cyan]Id[/]")
            .AddColumn("[cyan]Category[/]")
            .AddColumn("[cyan]Title[/]")
            .AddColumn("[cyan]Price[/]")
            .Alignment(Justify.Left)
            .BorderColor(Color.LightSlateGrey)
            .Alignment(Justify.Left)
            .Title("[LightGreen]Books[/]");

        table.Columns[0].Alignment(Justify.Right);
        table.Columns[3].Alignment(Justify.Right);

        return table;
    }
}