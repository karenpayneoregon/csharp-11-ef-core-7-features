
#nullable disable

namespace KP_WindowsFormsNET9.Models;

/// <summary>
/// Represents a user within the application for CountBy Role sample.
/// </summary>
public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public Role Role { get; set; }
}