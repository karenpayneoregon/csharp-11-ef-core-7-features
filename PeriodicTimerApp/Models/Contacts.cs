#nullable disable

namespace PeriodicTimerApp.Models;

public class Contacts 
{
    public int ContactId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int? ContactTypeIdentifier { get; set; }

    public string FullName { get; set; }

}