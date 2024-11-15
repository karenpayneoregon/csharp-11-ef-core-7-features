namespace KP_WindowsFormsNET9.EFCore.Sample1.Models;

/// <summary>
/// Represents a customer entity with basic details such as Id, Name, and <see cref="CustomerInfo"/>.
/// </summary>
public class Customer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required CustomerInfo CustomerInfo { get; set; }
}