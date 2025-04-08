using InterfaceExtensionApp.Interfaces;
using System.Text.RegularExpressions;

namespace InterfaceExtensionApp.Classes;

public static partial class Extensions
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

    /// <summary>
    /// Displays the details of the specified <see cref="IHuman"/> instance in a tabular format.
    /// </summary>
    /// <param name="human">
    /// The <see cref="IHuman"/> instance whose details are to be displayed.
    /// </param>
    /// <remarks>
    /// The method utilizes a styled table to present information such as ID, account, first name, last name, gender, 
    /// date of birth, and spoken language. The table is dynamically configured based on the type of the <see cref="IHuman"/> 
    /// instance and its implemented interfaces.
    /// </remarks>
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

    /// <summary>
    /// Creates and configures a new instance of the <see cref="Table"/> class for displaying human-related data.
    /// </summary>
    /// <returns>
    /// A <see cref="Table"/> instance with predefined columns for displaying information such as ID, account, first name, last name, gender, date of birth, and spoken language.
    /// </returns>
    /// <remarks>
    /// The table is styled with a rounded border, light slate grey border color, and a fixed width of 200.
    /// </remarks>
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

    /// <summary>
    /// Increments the trailing numeric portion of the specified string by 1.
    /// </summary>
    /// <param name="sender">The input string that ends with a numeric value.</param>
    /// <returns>
    /// A new string where the numeric portion at the end of the input string is incremented by 1,
    /// preserving the original length of the numeric portion with leading zeros if necessary.
    /// </returns>
    /// <exception cref="FormatException">
    /// Thrown if the trailing numeric portion of the string cannot be parsed as a valid number.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="sender"/> is <c>null</c>.
    /// </exception>
    public static string NextValue(this string sender)
    {
        string value = TrailingNumberRegex().Match(sender).Value;
        return sender[..^value.Length] + (long.Parse(value) + 1)
            .ToString().PadLeft(value.Length, '0');
    }



    [GeneratedRegex("[0-9]+$")]
    private static partial Regex TrailingNumberRegex();

}