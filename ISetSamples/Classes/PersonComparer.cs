using ISetSamples.Models;

namespace ISetSamples.Classes;

public class PersonComparer : IComparer<Person>
{
    public int Compare(Person left, Person right) 
        => string.Compare(left.LastName, right.LastName, StringComparison.Ordinal);
}