

namespace BinaryFormatterAlternate.Models;
/// <summary>
/// Represents a friend with personal details such as name, birthdate, and contact information.
/// </summary>
/// <remarks>
/// Used for serialization and deserialization of friend objects using the MessagePack library.
/// Note this is a ContractLess process which is useful when a developer does not want to use attributes to define the contract
/// or does not have access to a class to declarative the attributes.
/// </remarks>

public class Friend
{

    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateOnly BirthDate { get; set; }

    public string CellPhone { get; set; }   
}