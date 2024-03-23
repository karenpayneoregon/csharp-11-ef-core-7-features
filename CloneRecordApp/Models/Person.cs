namespace CloneRecordApp.Models;

public record Person
{
    public void Deconstruct(out int id, out string firstName, out string lastName, out List<Address> address)
    {
        id = Id;
        firstName = FirstName;
        lastName = LastName;
        address = Address;
    }

    public Person()
    {
    }

    public Person(int id, string firstName, string lastName, List<Address> address)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Address> Address { get; set; }
}