namespace RawStringLiteralsApp.Models;

internal class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }    
    public string LastName { get; set; }
    public string Title { get; set; }
    public override string ToString() => $"{Title} {FirstName} {LastName}";

}