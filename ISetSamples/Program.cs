using System.Collections.Frozen;
using ISetSamples.Models;
// ReSharper disable ArrangeObjectCreationWhenTypeNotEvident
#pragma warning disable CA1859
#pragma warning disable CA1859

namespace ISetSamples;

internal partial class Program
{
    static void Main(string[] args)
    {
        var frozenSet = FrozenPeople();
        foreach (var person in frozenSet)
            Console.WriteLine(person);
    }

    private static FrozenSet<Person> FrozenPeople()
    {
        
        ISet<Person> peopleSet = new HashSet<Person>([
            new() { Id = 1, FirstName = "Karen", LastName = "Payne", BirthDate = new DateOnly(1956,9,24)},
            new() { Id = 2, FirstName = "Sam", LastName = "Smith", BirthDate = new DateOnly(1976,3,4) },
            new() { Id = 1, FirstName = "Karen", LastName = "Payne", BirthDate = new DateOnly(1956,9,24) }
        ]);

        peopleSet.UnionWith([
            new() { Id = 1, FirstName = "Karen", LastName = "Payne", BirthDate = new DateOnly(1956,9,24)},
            new() { Id = 2, FirstName = "Sam", LastName = "Smith", BirthDate = new DateOnly(1976,3,4) },
            new() { Id = 3, FirstName = "Frank", LastName = "Adams", BirthDate = new DateOnly(1966,3,4) },
            new() { Id = 1, FirstName = "Karen", LastName = "Payne", BirthDate = new DateOnly(1956,9,24) }
        ]);

        peopleSet.ExceptWith([
            new() { Id = 2, FirstName = "Sam", LastName = "Smith", BirthDate = new DateOnly(1976,3,4) },
            new() { Id = 3, FirstName = "Frank", LastName = "Adams", BirthDate = new DateOnly(1966,3,4) },
        ]);

        return peopleSet.ToFrozenSet();
    }


}