using System.Runtime.CompilerServices;
using FormattableString1.Classes;

namespace FormattableString1;

internal partial class Program
{
    
    static void Main(string[] args)
    {
        PersonExample();
        Console.WriteLine();
        DayOfWeekExample();

        Console.ReadLine();
    }

    private static void DayOfWeekExample()
    {
        
        FormattableString format = FormattableStringFactory.Create("The weekend {0} {1} {2}",
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday);

        Console.WriteLine($"Format      : {format.Format}");
        Console.WriteLine($"# Arguments : {format.ArgumentCount}");
        Console.WriteLine($"Arguments   : {string.Join(",", format.GetArguments())}");

        format.GetArguments()[2] = DayOfWeek.Monday;

        Console.WriteLine($"Changed     : {string.Join(",", format.GetArguments())}");
        Console.WriteLine(format.ToString());

        Console.WriteLine("");

        for (int index = 0; index < format.ArgumentCount; index++)
        {
            Console.WriteLine($"{index,-4}{format.GetArguments()[index]}");
        }
    }

    private static void PersonExample()
    {
        Person person = new() { Id = 1, FirstName = "Karen", LastName = "Payne" };
        FormattableString format = FormattableStringFactory.Create("Id: {0} First {1} Last {2}",
            person.Id, person.FirstName, person.LastName);

        Console.WriteLine($"Last name null {(format.LastName() is null).ToYesNo()}");

        Console.WriteLine($"Format      : {format.Format}");
        Console.WriteLine($"# Arguments : {format.ArgumentCount}");
        
        Console.WriteLine(format.ArgumentsJoined());

        GetPropertyValues(format);
        UpdatePropertyValues(format);
        GetPropertyValues(format);

        Console.WriteLine(format.ToString());

        var hello = (FormattableString)$"{Howdy.TimeOfDay()}, {person.FirstName}!";
        Console.WriteLine(hello);

        for (int index = 0; index < format.ArgumentCount; index++)
        {
            Console.WriteLine($"{format.GetArgument(index)}");
            
        }
    }

    static void GetPropertyValues(FormattableString sender)
    {
        Console.WriteLine($"Id: {sender.Id()} First {sender.FirstName()} Last {sender.LastName()}");
    }
    static void UpdatePropertyValues(FormattableString sender)
    {
        sender.UpdateFirstName("Anne");
        sender.UpdateLastName("Adams");
    }
    
}