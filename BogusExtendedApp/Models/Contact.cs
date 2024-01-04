
namespace BogusExtendedApp.Models;

public class Contact
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ContactTypeIdentifier { get; set; }
    public ContactType ContactType { get; set; } = new();
    public override string ToString() => $"{FirstName} {LastName}";
    
    public Contact(int id)
    {
        Id = id;
    }

    public Contact()
    {

    }

}