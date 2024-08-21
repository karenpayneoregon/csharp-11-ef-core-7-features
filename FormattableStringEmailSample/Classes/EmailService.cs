using System.Runtime.CompilerServices;
using FormattableStringEmailSample.Interfaces;
using FormattableStringEmailSample.Models;

namespace FormattableStringEmailSample.Classes;
public class EmailService : IEmailService
{
    public string SendEmail(Person person, Manager manager) =>
        FormattableStringFactory.Create(
                """
                Hello {0} {1},

                {2}

                {3} {4}
                """,
                person.FirstName, person.LastName, 
                EmailMessages.WelcomeMessage, 
                manager.FirstName, manager.LastName)
            .ToString();
}
