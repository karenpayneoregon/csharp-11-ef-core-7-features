using StringSyntaxWithEntityFrameworkCore.Classes.Configuration;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using static System.Diagnostics.CodeAnalysis.StringSyntaxAttribute;
using Microsoft.EntityFrameworkCore;
using StringSyntaxWithEntityFrameworkCore.Data;
#pragma warning disable CS8629 // Nullable value type may be null.

namespace StringSyntaxWithEntityFrameworkCore.Classes;
internal class Operations
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class SyntaxAttribute : Attribute
    {
        public static string IdentifierFormat = FormatSettings.Instance.Items.IdentifierFormat;
        public static string AgeFormat = FormatSettings.Instance.Items.AgeFormat;
        public static string DateOnlyFormat = FormatSettings.Instance.Items.DateOnlyFormat;
    }
    public static async Task SpecialSyntax([Syntax()] string numbers = "")
    {
        var idFormat = SyntaxAttribute.IdentifierFormat;
        var dateFormat = SyntaxAttribute.DateOnlyFormat;
        var yearsOldFormat = SyntaxAttribute.AgeFormat;

        await using var context = new Context();
        var list = await context.BirthDays.ToListAsync();

        foreach (var item in list)
        {
            Debug.WriteLine($"{item.Id.ToString(idFormat),-5}{item.FirstName,-15}{item.LastName,-15}{item.BirthDate.Value.ToString(dateFormat),-12}" +
                            $"{item.YearsOld.Value.ToString(yearsOldFormat)}");
        }
    }
    public static async Task Syntax(
        [StringSyntax(NumericFormat)] string identifierFormat, [StringSyntax(DateOnlyFormat)] string dateFormat, [StringSyntax(NumericFormat)] string ageFormat)
    {

        await using var context = new Context();
        var list = await context.BirthDays.ToListAsync();

        foreach (var item in list)
        {
            Debug.WriteLine($"{item.Id.ToString(identifierFormat),-5}{item.FirstName,-15}{item.LastName,-15}{item.BirthDate.Value.ToString(dateFormat),-12}" +
                            $"{item.YearsOld.Value.ToString(ageFormat)}");
        }
    }
}
