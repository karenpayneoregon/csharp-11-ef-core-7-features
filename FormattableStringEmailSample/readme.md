# About

An example for [FormattableString](https://learn.microsoft.com/en-us/dotnet/api/system.formattablestring?view=net-8.0) Class. 

- Setup service
- Send email with FormattableString

```csharp
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

```