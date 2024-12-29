namespace InterfaceExtensionApp.Interfaces;
/// <summary>
/// Represents an entity with a unique identifier.
/// </summary>
/// <remarks>
/// This interface is implemented by classes that require an identifier property.
/// It is commonly used to standardize the identification of entities across the application.
/// </remarks>
public interface IIdentity
{
    public int Id { get; set; }
}