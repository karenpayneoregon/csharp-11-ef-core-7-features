namespace CloneRecordApp.Models;
public record Address
{
    public Address()
    {
    }

    public Address(int id, int personId, string street, string city, string state)
    {
        Id = id;
        PersonId = personId;
        Street = street;
        City = city;
        State = state;
    }

    public int Id { get; set; }
    public int PersonId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}