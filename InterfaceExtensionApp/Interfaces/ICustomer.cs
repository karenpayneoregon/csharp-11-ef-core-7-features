namespace InterfaceExtensionApp.Interfaces;
/// <summary>
/// Represents a customer entity with account-related information.
/// </summary>
/// <remarks>
/// This interface is implemented by classes that require customer-specific properties,
/// such as account details. It is commonly used in conjunction with other interfaces
/// like <see cref="IHuman"/> and <see cref="IIdentity"/> to provide a comprehensive
/// representation of a customer.
/// </remarks>
public interface ICustomer
{
    public string Account { get; set; }
}
