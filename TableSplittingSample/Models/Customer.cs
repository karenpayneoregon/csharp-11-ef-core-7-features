namespace TableSplittingSample.Models;
public class Customer
{
    public Customer(string name, string street, string city, string? postCode, string country)
    {
        Name = name;
        Street = street;
        City = city;
        PostCode = postCode;
        Country = country;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string? PostCode { get; set; }
    public string Country { get; set; }
}