using System.ComponentModel.DataAnnotations.Schema;

namespace KP_WindowsFormsNET9.EFCore.Sample1.Models;

/// <summary>
/// Represents an address with various components such as line1, line2, city, country, and postcode.
/// </summary>
/// <param name="Line1">The first line of the address.</param>
/// <param name="Line2">The second line of the address, which is optional.</param>
/// <param name="City">The city of the address.</param>
/// <param name="Country">The country of the address.</param>
/// <param name="PostCode">The postal code of the address.</param>
[ComplexType]
public record class Address(string Line1, string? Line2, string City, string Country, string PostCode);