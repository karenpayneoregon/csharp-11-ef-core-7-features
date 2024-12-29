using InterfaceExtensionApp.Interfaces;

namespace InterfaceExtensionApp.Models;

public class Person : IHuman, IIdentity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public Language Language { get; set; }
}