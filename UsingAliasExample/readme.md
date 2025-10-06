# Using alias directive to reference any kind of Type

Created the using alias  [feature](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-12.0/using-alias-types) and placed it in GlobalUsing.cs

```csharp
global using Baggage =
    (
        UsingAliasExample.Models.UserType Type,
        System.Collections.Generic.Dictionary<int, UsingAliasExample.Models.Person> People
    );
```

## Example

```csharp
internal partial class Program
{
    static void Main(string[] args)
    {
        Baggage storage = new()
        {
            Type = UserType.Developer,
            People = MockedData.FromDataSource()
        };

        DumpBaggage(storage);

        ExitPrompt();
    }
    private static void DumpBaggage(Baggage item)
    {
        Console.WriteLine(item.Type);
        foreach (var person in item.People)
        {
            Console.WriteLine($"   {person.Value}");
        }
    }
}
```

## Models

```csharp
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public override string ToString() => 
        $"{Id,-4}{FirstName,-10}{LastName,-15}";
}
public enum UserType
{
    Developer,
    Tester
}
```

## Mocked data

```csharp
internal class MockedData
{
    public static Dictionary<int, Person> FromDataSource()
    {
        return new Dictionary<int, Person>()
        {
            [1] = new() { Id = 23, FirstName = "Karen", LastName = "Payne" },
            [2] = new() { Id = 24, FirstName = "Anne", LastName = "Jenkins" },
            [3] = new() { Id = 25, FirstName = "Mike", LastName = "Burton" }
        };
    }
}
```
