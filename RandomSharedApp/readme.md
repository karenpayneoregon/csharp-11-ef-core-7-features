# About

New for `net8`, GetItems`<T>`()

The new [System.Random.GetItems](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8#getitemst) methods let you randomly choose a specified number of items. 

## Mocked data

In this code sample, [Bogus](https://www.nuget.org/packages/Bogus) is used to provide mocked data.

```csharp
internal class BogusOperations
{
    public static List<Human> People(int count = 15)
    {
        int identifier = 1;
        Faker<Human> fakePerson = new Faker<Human>()
            .CustomInstantiator(f => new Human(identifier++))
            .RuleFor(p => p.FirstName, f => f.Person.FirstName)
            .RuleFor(p => p.LastName, f => f.Person.LastName);

        return fakePerson.Generate(count);

    }
}
```

## Main code to generate random data

```csharp
var people = BogusOperations
    .People(100)
    .OrderBy(x => x.LastName)
    .ToArray();

for (int index = 0; index < 10; index++)
{
    AnsiConsole.MarkupLine($"[cyan]Pass[/] " +
                           $"[yellow]{index +1}[/]");
    var items = Random.Shared.GetItems(people, 3);
    await Task.Delay(500);
    foreach (var human in items)
    {
        Console.WriteLine($"{human.Id,-5}{human.FirstName,-20}" +
                          $"{human.LastName}");
    }
}
```


