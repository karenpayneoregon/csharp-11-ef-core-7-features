#nullable disable

using KP_WindowsFormsNET9.Models;

namespace KP_WindowsFormsNET9.Classes;

public class MockedData
{
    /// <summary>
    /// Retrieves a list of mocked user data for CountBy code sample.
    /// </summary>
    /// <returns>A list of <see cref="User"/> objects representing mocked user data.</returns>
    public static List<User> Users() =>
    [
        new() { Id = 1, UserName = "John", Role = Role.Admin },
        new() { Id = 2, UserName = "Jane", Role = Role.Member },
        new() { Id = 3, UserName = "Joe", Role = Role.Guest },
        new() { Id = 4, UserName = "Alice", Role = Role.Admin },
        new() { Id = 5, UserName = "Bob", Role = Role.Member },
        new() { Id = 6, UserName = "Charlie", Role = Role.Guest },
        new() { Id = 7, UserName = "Dave", Role = Role.Admin },
        new() { Id = 8, UserName = "Eve", Role = Role.Member },
        new() { Id = 9, UserName = "Frank", Role = Role.Guest },
        new() { Id = 10, UserName = "Grace", Role = Role.Admin }
    ];

}