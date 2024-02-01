namespace PrimaryConstructorIComparerApp.Models;
public class Student(string firstName, string lastName, double grade)
{
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public double Grade { get; set; } = grade;
    
    public override string ToString() 
        => $"{FirstName, -10} {LastName, -10} {Grade}";
}