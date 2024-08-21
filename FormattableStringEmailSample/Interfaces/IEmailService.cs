using FormattableStringEmailSample.Models;

namespace FormattableStringEmailSample.Interfaces;

public interface IEmailService
{
    string SendEmail(Person person, Manager manager);
}