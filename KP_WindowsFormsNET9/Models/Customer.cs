#nullable disable
using KP_WindowsFormsNET9.Classes;

namespace KP_WindowsFormsNET9.Models;

/// <summary>
/// Field Keyword example.
/// </summary>
public class Customer
{
    /// <summary>
    /// Gets or sets the unique identifier for the customer.
    /// </summary>
    /// <value>
    /// The unique identifier for the customer.
    /// </value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the first name of the customer.
    /// </summary>
    /// <value>
    /// The first name of the customer, with leading and trailing whitespace removed.
    /// </value>
    public string FirstName
    {
        get;
        set => field = value.CapitalizeFirstLetter();
    }
    /// <summary>
    /// Gets or sets the last name of the customer.
    /// </summary>
    /// <value>
    /// The last name of the customer.
    /// </value>
    public string LastName
    {
        get;
        set => field = value.CapitalizeFirstLetter();
    }
}