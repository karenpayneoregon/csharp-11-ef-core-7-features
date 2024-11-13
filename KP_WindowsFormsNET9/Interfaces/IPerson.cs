namespace KP_WindowsFormsNET9.Interfaces;


/// <summary>
/// Represents a person with properties for accessing and modifying their details.
/// </summary>
public interface IPerson
{
    public string this[int index] { get; set; }
}