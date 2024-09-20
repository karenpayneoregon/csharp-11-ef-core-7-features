# About

Ongoing switch expression samples

**Reverse indexing**

```csharp
public static void MonthsIndexed()
{
    var table = new Table()
        .RoundedBorder().BorderColor(Color.LightSlateGrey)
        .AddColumn("[b]Name[/]").AddColumn("[b]Index[/]").Alignment(Justify.Center)
        .Title("[yellow]Months index reverse[/]");

    var months = DateTimeFormatInfo.CurrentInfo.MonthNames[..^1].ToList();


    for (int index = months.Count; index != 0; index--)
    {
        var currentIndex = new Index(index, true);
        table.AddRow(months[currentIndex].ToString(), currentIndex.ToString());
    }

    AnsiConsole.Write(table);

}
```

![image](../assets/MonthsReverseIndexed.png)

**Complex**

```csharp
public static void RecursivePatternMatching()
{
    const string state = "WA";

    Console.WriteLine(nameof(RecursivePatternMatching));

    SomeType someType = new ()
    {
        FirstName = "Karen",
        LastName = "Payne",
        ShipmentStatus = Shipment.State.Delivered,
        Address = new Address() { Street = "123 Apple street", State = "OR", Zip = "1111" }
    };

    var message = someType switch
    {
        { ShipmentStatus: Shipment.State.Ordered } => "Congrats on your order",
        { Address: { State: state } } => "I live there too!",
        { Address: { Zip: null } } => "You forgot to enter a zip code!",
        {
            ShipmentStatus: Shipment.State.Delivered,
            FirstName: (var firstName),
            LastName: (var lastName)
        } => $"Enjoy your package {firstName} {lastName}!",
        null => throw new ArgumentNullException(),
        _ => "I'm not sure what I'm looking at here."
    };

    Console.WriteLine(message);
}
```
