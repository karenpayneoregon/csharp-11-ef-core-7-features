using InterfaceExtensionApp.Interfaces;

namespace InterfaceExtensionApp.Models;

public class Customer : IHuman, IIdentity, ICustomer
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public required Gender Gender { get; set; }
    public Language Language { get; set; }
    public string Account { get; set; }

}

public class Address : IIdentity, IAddress
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
}

public interface IAddress
{
    public int ParentId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
}


public interface IProduct
{
    string ProductName { get; set; }
    int? SupplierId { get; set; }
    int? CategoryId { get; set; }
}

public class Product : IIdentity, IProduct
{
    public int Id  { get; set; }
    public int ProductId => Id;
    public string ProductName { get; set; }
    public int? SupplierId { get; set; }
    public int? CategoryId { get; set; }
}
