using RawStringLiteralsApp.Models;
using System.Runtime.CompilerServices;
using RawStringLiteralsApp.Classes;

namespace RawStringLiteralsApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            ColorExample();
            MimicEmailMessage();
            WithGenericMath();

            Console.ReadLine();
        }

        private static void WithGenericMath()
        {
            Print();

            int value = 2;

            var rawInterpolated = $"""
    The result variable [cyan]int value = 2[/] is [cyan]Even[/]? [yellow]{ value.IsEven().ToYesNoString()} [/]
                                 Or is it [cyan]odd[/]? { value.IsOdd().ToYesNoString()} 
    """ ;
            AnsiConsole.MarkupLine(rawInterpolated);

        }

        private static void MimicEmailMessage()
        {
            Person person = new Person() { FirstName = "James", Title = "Mr", LastName = "Smith" };
            string companyName = "Acme";
            string phone = "555-123-4565";
            var emailMessage = EmailMessageTemplate(person, companyName, phone);

            Console.WriteLine();
            AnsiConsole.MarkupLine(emailMessage);
            Console.WriteLine();
        }

        /// <summary>
        /// Super simple example for creating a template
        /// For a robust solution there are plenty of packages out there e.g.
        /// https://github.com/lukencode/FluentEmail
        /// But for small task raw string literals work well.
        /// </summary>
        private static string EmailMessageTemplate(Person person, string companyName, string phone)
        {
            Print();
            string emailMessage = $$"""
            Hello {{ person.Title}}  {{ person.LastName}},

            We are super excited to welcome you to {{ companyName}} 
            If there is any questions call us at {{ phone}} 
            """ ;
            return emailMessage;
        }

        private static void ColorExample()
        {
            Print();
            string text = "[red]I've been injected[/] ";
            string longMessage = $$"""
            This is a long message.
            It has several lines.
                Some are indented
                        more than others. {{ text}} 
            Some should start at the first column.
            Some have "quoted text" in them.
            """ ;

            Console.WriteLine();
            AnsiConsole.MarkupLine(longMessage);
            Console.WriteLine();
        }

        private static void Print([CallerMemberName] string? methodName = null)
        {
            AnsiConsole.MarkupLine($"[white on blue]{methodName.SplitCamelCase()}[/]");
            Console.WriteLine();
        }
    }
}