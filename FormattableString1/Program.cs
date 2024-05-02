using System.Runtime.CompilerServices;
using FormattableString1.Classes;

namespace FormattableString1;

internal partial class Program
{
    
    static void Main(string[] args)
    {
        Person person = new() { Id = 1, FirstName = "Karen", LastName = "Payne" };
        FormattableString format = FormattableStringFactory.Create("Id: {0} First {1} Last {2}",
            person.Id, person.FirstName, person.LastName);
        
        Console.WriteLine(format.ArgumentsJoined());
        
        GetPropertyValues(format);
        UpdatePropertyValues(format);
        GetPropertyValues(format);
        
        Console.WriteLine(format.ToString());

        var hello = (FormattableString)$"{Howdy.TimeOfDay()}, {person.FirstName}!";
        Console.WriteLine(hello);

        Console.ReadLine();
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