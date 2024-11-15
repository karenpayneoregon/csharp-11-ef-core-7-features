namespace KP_WindowsFormsNET9.EFCore.Sample1.Models;

/// <summary>
/// Represents a store entity with an identifier, a list of associated customers, a region, and an address.
/// </summary>
public class Store
{
    public int Id { get; set; }
    public List<CustomerWithStores> Customers { get; } = [];
    public string? Region { get; set; }
    public required Address StoreAddress { get; set; }
}