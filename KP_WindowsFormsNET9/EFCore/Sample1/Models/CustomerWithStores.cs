namespace KP_WindowsFormsNET9.EFCore.Sample1.Models;

/// <summary>
/// Represents a customer who is associated with multiple stores.
/// </summary>
public class CustomerWithStores
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Region { get; set; }
    public string? Tag { get; set; }
}