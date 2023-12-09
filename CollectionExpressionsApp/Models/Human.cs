namespace CollectionExpressionsApp.Models;
public class Human
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

public class Employee : Human
{
    public string Title { get; set; }
}