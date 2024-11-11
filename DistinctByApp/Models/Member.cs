#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace DistinctByApp.Models;

/// <summary>
/// Represents a member with personal details and address information.
/// </summary>
public class Member
{
    public int Id { get; set; }
    public bool Active { get; set; }
    public string FirstName { get; set; }
    public string SurName { get; set; }
    public Gender Gender { get; set; }
    public Address Address { get; set; }
    public override string ToString() => Id.ToString();
}