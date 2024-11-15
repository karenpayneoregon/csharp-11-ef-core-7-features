using System.ComponentModel.DataAnnotations.Schema;

namespace KP_WindowsFormsNET9.EFCore.Sample1.Models;

/// <summary>
/// Represents a special type of customer in a Table-per-Type (TPT) inheritance model.
/// </summary>

[Table("TptSpecialCustomers")]
public class SpecialCustomerTpt : CustomerTpt
{
    public string? Note { get; set; }
}