namespace RandomSharedApp.Models;
internal class Human
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public override string ToString() => $"{FirstName} {LastName}";

    public Human()
    {
        
    }

    public Human(int id)
    {
        Id = id ;
    }
}
