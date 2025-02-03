# About

It provides easy access to database connections and a setting for EF Core to indicate whether a database should be recreated and tables populated from static data or data generated from the NuGet package Bogus.

## See the following example projects.

These projects have product and category tables that are populated with the same data. 

- RazorHasData
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

### ASP.NET Core

```csharp
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        /*
         * Setup for connection string and mocking data
         */
        await MainConfiguration.Setup();

        builder.Services.AddRazorPages();

        /*
         * Connection string from appsettings.json
         * Sensitive data logging enabled
         * Logs to a text file
         */
        builder.Services.AddDbContext<Context>(options =>
            options.UseSqlServer(DataConnections.Instance.MainConnection)
                .EnableSensitiveDataLogging()
                .LogTo(action: new DbContextToFileLogger().Log));


        SetupLogging.Development();
        var app = builder.Build();

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