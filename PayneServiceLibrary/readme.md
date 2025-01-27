# About

It provides easy access to database connections and a setting for EF Core to indicate whether a database should be recreated and tables populated from static data or data generated from the NuGet package Bogus.

## See the following example projects.

Both projects have product and category tables that are populated with the same data. 

- SqliteHasData
- SqlServerHasData

## Setup

### Console project

```csharp
internal partial class Program
{
    private static async Task Main(string[] args)
    {
        await MainConfiguration.Setup();
    }
}
```

### Windows Forms

```csharp
internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static async Task Main()
    {

        ApplicationConfiguration.Initialize();

        await MainConfiguration.Setup();

        Application.Run(new Form1());
    }
}
```

## Sample configration file

Use `MainConnection` for general connections and `SecondaryConnection` for additional connections.

```json
{
  "ConnectionStrings": {
    "MainConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HasDataExample;Integrated Security=True;Encrypt=False",
    "SecondaryConnection": "..."
  },
  "EntityConfiguration": {
    "CreateNew": true
  }
}
```