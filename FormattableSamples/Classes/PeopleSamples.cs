using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FormattableSamples.Models;

namespace FormattableSamples.Classes;
internal class PeopleSamples
{
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

        var hello = (FormattableString)$"{Greetings.TimeOfDay()}, {person.FirstName}!";
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
