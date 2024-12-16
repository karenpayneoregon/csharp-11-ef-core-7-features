using InterfaceExtensionApp.Interfaces;

namespace InterfaceExtensionApp.Classes;

public static class Extensions
{
    public static void Print(this IHuman human)
    {
        Console.WriteLine($"      Type: {human.GetType().Name}");

        if (human is IIdentity identity)
        {
            Console.WriteLine($"        Id: {identity.Id}");
        }

        Console.WriteLine($"First Name: {human.FirstName}");
        Console.WriteLine($" Last Name: {human.LastName}");
        Console.WriteLine($"    Gender: {human.Gender}");
        Console.WriteLine($"     Birth: {human.DateOfBirth}");
    }
}