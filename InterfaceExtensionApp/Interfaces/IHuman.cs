using InterfaceExtensionApp.Models;

namespace InterfaceExtensionApp.Interfaces;

public interface IHuman
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public Gender Gender { get; set; }
}