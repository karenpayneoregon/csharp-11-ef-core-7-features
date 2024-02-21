using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace BogusProperGenderApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Bogus proper gender code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
    public static Table CreateTable()
        => new Table().RoundedBorder()
            .AddColumn("[cyan]First[/]")
            .AddColumn("[cyan]Last[/]")
            .AddColumn("[cyan]Gender[/]")
            .AddColumn("[cyan]Birth[/]")
            .AddColumn("[cyan]Email[/]")
            .Alignment(Justify.Left)
            .BorderColor(Color.LightSlateGrey)
            .Border(TableBorder.Square)
            .Title("[LightGreen]Customers[/]");
}
