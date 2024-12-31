using System.Diagnostics;
using NewStuffApp.Models;

namespace NewStuffApp.Classes;

/// <summary>
/// Provides a set of static methods for iterating over collections of various types 
/// (e.g., strings, integers, and Person) and performing operations on them.
/// </summary>
internal class Params
{
    public static void Iterate(params IEnumerable<string> values)
    {
        foreach (var (index, item) in values.Index())
            Debug.WriteLine($"{index,-5}{item}");
    }
    public static void Iterate(params IEnumerable<int> values)
    {
        foreach (var (index, item) in values.Index())
            Debug.WriteLine($"{index,-5}{item}");
    }
    public static void Iterate(params IEnumerable<Person> values)
    {
        foreach (var (index, item) in values.Index())
            Debug.WriteLine($"{index,-5}{item.FirstName} {item.LastName}");
    }
    public static void Examples()
    {
        Iterate(1, 2, 3, 4, 5);
        Iterate([6, 7, 8]);
        Iterate("Sam", "Anne", "Mary", "Dan", "Kim");
        Iterate(["Jim", "Tony", "Lisa"]);
        Iterate(BogusOperations.PersonsList(2));
    }
}
