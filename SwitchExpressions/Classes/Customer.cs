namespace SwitchExpressions.Classes;

/// <summary>
/// Represents a customer with personal details and shipment status.
/// </summary>
public class Customer
{
    /// <summary>
    /// Gets or sets the first name of the customer.
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// Gets or sets the last name of the customer.
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// Gets or sets the address of the customer.
    /// </summary>
    public Address Address { get; set; }
    /// <summary>
    /// Gets or sets the shipment status of the customer.
    /// </summary>
    public Shipment.State ShipmentStatus { get; set; }
    /// <summary>
    /// Deconstructs the customer object into first name and last name.
    /// </summary>
    /// <param name="firstName">The first name of the customer.</param>
    /// <param name="lastName">The last name of the customer.</param>
    public void Deconstruct(out string firstName, out string lastName)
    {
        firstName = FirstName;
        lastName = LastName;
    }
}

