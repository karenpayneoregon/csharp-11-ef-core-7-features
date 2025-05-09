namespace BogusProperGenderApp.Models;

public class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateOnly BirthDay { get; set; }

    public string Email { get; set; }

    public Gender? Gender { get; set; }
    public override string ToString() => $"{Id,-3}{FirstName,-7}{LastName,-10} ~ ";
}