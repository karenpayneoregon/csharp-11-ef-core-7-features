using BogusProperGenderEntityApp.Classes;
using BogusProperGenderEntityApp.Data;
using BogusProperGenderEntityApp.Models;
using Microsoft.EntityFrameworkCore;


namespace BogusProperGenderEntityApp;
internal partial class Program
{

    static async Task Main(string[] args)
    {

        await Setup();
        await using var context = new Context();
        if (EntitySettings.Instance.CreateNew)
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
        }

        var people = await context.BirthDays.ToListAsync();

        var table = CreateTable();
        foreach (var p in people)
        {
            if (p.Gender == Gender.Male)
            {
                table.AddRow(p.Id.ToString(), p.FirstName, p.LastName, p.Gender.ToString(), p.BirthDate.Value.ToString(), p.YearsOld.ToString(), p.Email);
            }
            else
            {
                table.AddRow(p.Id.ToString(), p.FirstName, p.LastName, $"[cyan]{p.Gender.ToString()}[/]", p.BirthDate.Value.ToString(), p.YearsOld.ToString(), p.Email);
            }
        }

        AnsiConsole.Write(table);
        ExitPrompt();


  
    }

    private static Table CreateTable()
        => new Table().RoundedBorder().LeftAligned()
            .AddColumn("[cyan]Id[/]")
            .AddColumn("[cyan]First[/]")
            .AddColumn("[cyan]Last[/]")
            .AddColumn("[cyan]Gender[/]")
            .AddColumn("[cyan]Birth[/]")
            .AddColumn(new TableColumn("[yellow]Years old[/]").RightAligned())
            .AddColumn("[cyan]Email[/]")
            .BorderColor(Color.LightSlateGrey)
            .Border(TableBorder.Square)
            .Title("[LightGreen]Birth days[/]");
}

