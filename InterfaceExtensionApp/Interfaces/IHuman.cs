using InterfaceExtensionApp.Models;

namespace InterfaceExtensionApp.Interfaces;

/// <summary>
/// Represents a human entity with basic personal information such as name, date of birth, gender, and language.
/// </summary>
/// <remarks>
/// This interface defines the essential properties that characterize a human entity.
/// It can be implemented by various classes to represent specific types of humans, such as customers or persons.
/// </remarks>
public interface IHuman
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public Language Language { get; set; }
}