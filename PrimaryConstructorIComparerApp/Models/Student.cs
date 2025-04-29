using PrimaryConstructorIComparerApp.Interfaces;

namespace PrimaryConstructorIComparerApp.Models;

/// <summary>
/// Represents a student with an ID, first name, last name, and grade.
/// </summary>
/// <param name="id">The unique identifier of the student.</param>
/// <param name="firstName">The first name of the student.</param>
/// <param name="lastName">The last name of the student.</param>
/// <param name="grade">The grade of the student.</param>
public class Student(int id, string firstName, string lastName, double grade) : IStudent, IBase
{
    public int Id { get; set; } = id;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public double Grade { get; set; } = grade;
    
    public override string ToString() 
        => $"{Id, -5}{FirstName, -10} {LastName, -10} {Grade}";
}