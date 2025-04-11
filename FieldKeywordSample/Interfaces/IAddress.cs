namespace FieldKeywordSample.Interfaces;

public interface IAddress
{
    int Id { get; set; }
    int CustomerId { get; set; }
    string Street { get; set; }
    string City { get; set; }
    string State { get; set; } 
    string ZipCode { get; set; }
    string Country { get; set; }
    string Phone { get; set; }
}
