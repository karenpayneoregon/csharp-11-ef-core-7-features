using StringTokenFormatter;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace StringSyntaxAttributeExampleApp.Classes;
public class Operations
{
    public static void SetDateFormat([StringSyntax(StringSyntaxAttribute.DateTimeFormat)] string format, params object[] arguments)
    {
   

    }

    public static void FormatRex([StringSyntax(StringSyntaxAttribute.Regex)] string regex)
    {
        
    }

    public static void SetNumberFormat([StringSyntax(StringSyntaxAttribute.NumericFormat)] string sender)
    {
        
    }
    public static void CompositeFormat([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string sender)
    {


        string firstName = "Karen";
        string lastName = "Payne";
        string result = string.Format(sender, firstName, lastName);


        FormattableString format = FormattableStringFactory.Create(sender, firstName,lastName, "S");
    }


    public static void Demo()
    {
        var customer = new
        {
            Name = "Karen Payne",
            IsFirstOrder = true,
        };

        static string OrderIdFormatter(int id, string _format) => $"#{id:000000}";
        static string GuidFormatter(Guid guid, string format) =>
            format == "Initial" ? guid.ToString("D").Split('-')[0].ToUpper() : guid.ToString();

        var settings = StringTokenFormatterSettings.Default with
        {
            FormatProvider = CultureInfo.GetCultureInfo("en-US"),
            FormatterDefinitions = new[] {
                FormatterDefinition.ForTokenName<int>("Order.Id", OrderIdFormatter),
                FormatterDefinition.ForType<Guid>(GuidFormatter),
            },
        };

        var resolver = new InterpolatedStringResolver(settings);
        string templateString = new StringBuilder()
            .AppendLine("Hi {Customer.Name},")
            .AppendLine("Thank you for {:map,Customer.IsFirstOrder:true=your first order,false=your order}.")
            .Append("Ref: {MessageId:Initial}")
            .ToString();
        var interpolatedString = resolver.Interpolate(templateString);
        var combinedContainer = resolver.Builder()
            .AddPrefixedObject("Customer", customer)
            .AddSingle("MessageId", new Lazy<object>(() => Guid.Parse("73054fad-ba31-4cc2-a1c1-ac534adc9b45")))
            .CombinedResult();


        string actual = resolver.FromContainer(interpolatedString, combinedContainer);

    }
}
