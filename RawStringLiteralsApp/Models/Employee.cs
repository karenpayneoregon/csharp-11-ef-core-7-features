namespace RawStringLiteralsApp.Models;

public abstract class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
}
public class Employee : Person
{
    public int Id { get; set; }

    public override string ToString() => $"{Title} {FirstName} {LastName}";

}