using PrintMembersSamples.Models;

namespace PrintMembersSamples.Classes;

public class PersonRepository
{
    public static List<Person> SamplePeople() =>
    [
        new Person("Karen", "Payne", new DateOnly(1985, 1, 15), ["555-1234", "555-5678"]),
        new Person("Jane", "Smith", new DateOnly(1990, 5, 22), ["555-8765"]),
        new Person("Michael", "Johnson", new DateOnly(1978, 3, 10), ["555-1111", "555-2222"]),
        new Person("Emily", "Davis", new DateOnly(1995, 7, 30), ["555-3333"]),
        new Person("William", "Brown", new DateOnly(1980, 12, 5), ["555-4444"]),
        new Person("Linda", "Taylor", new DateOnly(1988, 2, 18), ["555-5555"]),
        new Person("Robert", "Anderson", new DateOnly(1972, 11, 9), ["555-6666", "555-7777"]),
        new Person("Patricia", "Thomas", new DateOnly(1993, 6, 25), ["555-8888"]),
        new Person("David", "Jackson", new DateOnly(1983, 4, 3), ["555-9999"]),
        new Person("Barbara", "White", new DateOnly(1975, 9, 17), ["555-0000"])
    ];
}