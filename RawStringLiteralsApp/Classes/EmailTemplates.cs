using RawStringLiteralsApp.Models;
namespace RawStringLiteralsApp.Classes;

    public static class EmailTemplates
    {
        public static string CreateWelcomeMessage(Employee person) =>
            $"""
              Hello {person.Title} {person.LastName},

              We are super excited to welcome you to {Company.Name}
              If there is any questions call us at {Company.HumanResourcePhone}
              """;
    }

    public static class Extensions
    {
        public static string CreateWelcomeMessage(this Employee person) =>
            $"""
              Hello {person.Title} {person.LastName},

              We are super excited to welcome you to {Company.Name}
              If there is any questions call us at {Company.HumanResourcePhone}
              """;
    }

    public static class Company
    {
        public static string Name => "Acme Inc";
        public static string HumanResourcePhone => "555-123-4565";
    }

    public class EmailOperations
    {
        // fake method
        public static void SendWelcomeMessage(string message)
        {
            Console.WriteLine(message);
        }
    }