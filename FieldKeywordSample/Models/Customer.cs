using FieldKeywordSample.Interfaces;

namespace FieldKeywordSample.Models;

/// <summary>
/// Represents a customer entity that inherits from <see cref="Person"/> and implements the <see cref="ICustomer"/> interface.
/// </summary>
/// <remarks>
/// This class includes customer-specific properties such as <see cref="CustomerId"/> and a collection of <see cref="Address"/> objects.
/// </remarks>
public class Customer : Person, ICustomer
{
    /// <summary>
    /// Gets or sets the unique identifier for the customer.
    /// </summary>
    /// <value>
    /// The unique identifier for the customer.
    /// </value>
    public int CustomerId { get; set; }

    public List<Address> Addresses
    {
        get;
        set => field = value ?? field;
    }

}