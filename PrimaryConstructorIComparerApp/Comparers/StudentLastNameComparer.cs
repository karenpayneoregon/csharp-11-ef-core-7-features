#nullable enable
using PrimaryConstructorIComparerApp;
using PrimaryConstructorIComparerApp.Models;

namespace PrimaryConstructorIComparerApp.Comparers;

#pragma warning disable CS8602
/// <summary>
/// Order students by last name
/// </summary>
public class StudentLastNameComparer : IComparer<Student>
{
    public int Compare(Student? x, Student? y)
        => string.Compare(x.LastName, y.LastName, StringComparison.OrdinalIgnoreCase);
}