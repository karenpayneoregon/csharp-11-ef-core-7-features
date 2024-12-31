using InterfaceExtensionApp.Interfaces;

namespace InterfaceExtensionApp.Classes;

public static class Extensions
{
    /// <summary>
    /// Displays detailed information about the specified <see cref="IHuman"/> object.
    /// </summary>
    /// <param name="human">The <see cref="IHuman"/> instance whose information is to be displayed.</param>
    /// <remarks>
    /// If the <paramref name="human"/> implements the <see cref="IIdentity"/> interface, the ID is displayed.
    /// If the <paramref name="human"/> implements the <see cref="ICustomer"/> interface, the account information is displayed.
    /// The method also outputs the first name, last name, gender, date of birth, and language of the <paramref name="human"/>.
    /// </remarks>
    public static void Display(this IHuman human)
    {
        Console.WriteLine($"      Type: {human.GetType().Name}");

        if (human is IIdentity identity)
        {
            Console.WriteLine($"        Id: {identity.Id}");
        }

        if (human is ICustomer customer)
        {
            Console.WriteLine($"   Account: {customer.Account}");
        }

        Console.WriteLine($"First Name: {human.FirstName}");
        Console.WriteLine($" Last Name: {human.LastName}");
        Console.WriteLine($"    Gender: {human.Gender}");
        Console.WriteLine($"     Birth: {human.DateOfBirth}");
        Console.WriteLine($"  Language: {human.Language}");
    }
    public static void DisplayWithTable(this IHuman human)
    {

        var table = CreateTable();
        table.Title = new TableTitle($"[white]Type:[/] [yellow]{human.GetType().Name}[/]");

        table.AddRow(
            human is IIdentity identity ? identity.Id.ToString() : string.Empty,
            human is ICustomer customer ? $"[orange3]{customer.Account}[/]" : string.Empty,
            human.FirstName,
            human.LastName,
            human.Gender.ToString(),
            human.DateOfBirth.ToString(),
            human.Language.ToString());

        AnsiConsole.Write(table);

    }

    private static Table CreateTable()
        => new Table()
            .AddColumn("[cyan]Id[/]")
            .AddColumn("[cyan]Account[/]")
            .AddColumn("[cyan]First[/]")
            .AddColumn("[cyan]Last[/]")
            .AddColumn("[cyan]Gender[/]")
            .AddColumn("[cyan]Birth[/]")
            .AddColumn("[cyan]Spoken[/]")
            .BorderColor(Color.LightSlateGrey)
            .Width(200)
            .Border(TableBorder.Rounded);

}