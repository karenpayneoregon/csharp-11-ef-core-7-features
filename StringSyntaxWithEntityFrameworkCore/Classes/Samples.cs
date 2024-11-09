using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using StringSyntaxWithEntityFrameworkCore.Classes.Configuration;
using StringSyntaxWithEntityFrameworkCore.Data;

// for StringSyntax
using static System.Diagnostics.CodeAnalysis.StringSyntaxAttribute;

namespace StringSyntaxWithEntityFrameworkCore.Classes;
internal class Samples
{
    /// <summary>
    /// Get formats from appsettings.json, see <see cref="SetupServices"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class AppSyntaxAttribute : Attribute
    {
        public static string IdentifierFormat = FormatSettings.Instance.Items.IdentifierFormat;
        public static string AgeFormat = FormatSettings.Instance.Items.AgeFormat;
        public static string DateOnlyFormat = FormatSettings.Instance.Items.DateOnlyFormat;
    }

    /// <summary>
    /// Example showing hard coded formatting for Id, BirthDate, and YearsOld properties.
    /// </summary>
    public static async Task Conventional()
    {
        Debug.WriteLine($"-------------------{nameof(Conventional)}----------------------");

        await using var context = new Context();
        var list = await context.BirthDays.ToListAsync();

        foreach (var item in list)
        {
            // line broken for readability
            Debug.WriteLine($"{item.Id,-5:D2}" +
                            $"{item.FirstName,-15}" +
                            $"{item.LastName,-15}" +
                            $"{item.BirthDate!.Value,-12:MM/dd/yyyy}" +
                            $"{item.YearsOld!.Value:D3}");
        }
    }


    /// <summary>
    /// Formats and displays a list of birthdays using the specified formats for ID, date, and age.
    /// </summary>
    /// <param name="identifierFormat">The format string for the ID.</param>
    /// <param name="dateFormat">The format string for the birthdate.</param>
    /// <param name="ageFormat">The format string for the age.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task Syntax(
        [StringSyntax(NumericFormat)] string identifierFormat,
        [StringSyntax(DateOnlyFormat)] string dateFormat,
        [StringSyntax(NumericFormat)] string ageFormat)
    {
        
        Debug.WriteLine($"-------------------{nameof(Syntax)}----------------------");

        await using var context = new Context();
        var list = await context.BirthDays.ToListAsync();

        foreach (var item in list)
        {
            // line broken for readability
            Debug.WriteLine($"{item.Id.ToString(identifierFormat),-5}" +
                            $"{item.FirstName,-15}" +
                            $"{item.LastName,-15}" +
                            $"{item.BirthDate!.Value.ToString(dateFormat),-12}" +
                            $"{item.YearsOld!.Value.ToString(ageFormat)}");
        }
    }

    public async Task SpecialSyntax([AppSyntax()] string numbers = "")
    {
        var idFormat = AppSyntaxAttribute.IdentifierFormat;
        var dateFormat = AppSyntaxAttribute.DateOnlyFormat;
        var yearsOldFormat = AppSyntaxAttribute.AgeFormat;

        Debug.WriteLine($"-------------------{nameof(SpecialSyntax)}----------------------");

        await using var context = new Context();
        var list = await context.BirthDays.ToListAsync();

        foreach (var item in list)
        {
            // line broken for readability
            Debug.WriteLine($"{item.Id.ToString(idFormat),-5}" +
                            $"{item.FirstName,-15}" +
                            $"{item.LastName,-15}" +
                            $"{item.BirthDate!.Value.ToString(dateFormat),-12}" +
                            $"{item.YearsOld!.Value.ToString(yearsOldFormat)}");


        }
    }
}
