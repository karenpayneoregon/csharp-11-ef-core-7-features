namespace FieldKeywordSample.Interfaces;

public interface ICustomer
{
    /// <summary>
    /// Gets or sets the unique identifier for the customer.
    /// </summary>
    /// <value>
    /// The unique identifier for the customer.
    /// </value>
    int CustomerId { get; set; }
}