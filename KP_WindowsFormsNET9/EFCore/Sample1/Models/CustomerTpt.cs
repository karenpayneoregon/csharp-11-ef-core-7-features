using System.ComponentModel.DataAnnotations.Schema;

namespace KP_WindowsFormsNET9.EFCore.Sample1.Models;

/// <summary>
/// Represents a customer entity in a Table-per-Type (TPT) inheritance model.
/// </summary>

[Table("TptCustomers")]
public class CustomerTpt
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required CustomerInfo CustomerInfo { get; set; }
}