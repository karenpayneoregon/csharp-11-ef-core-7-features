# About

This project demonstrates using Bogus to mockup data for `SQL-Server database`, converts enumerations and has a computed column on a date column using a DateOnly column to get a person’s years old using `EF Core 8`.

- Database and tables are created using Entity Framework Core HasData in the DbContext using [Bogus](https://www.nuget.org/packages/Bogus) NuGet package.
- Mocked data is the same for each run as per using Bogus [Seed](https://github.com/bchavez/Bogus?tab=readme-ov-file#the-great-c-example).
- For the most part gender matches first name, but there are some exceptions so there are no guaranteed but for the project they are correct.

![Title](assets/title.png)

## See also

- [Using EF Core and Bogus](https://dev.to/karenpayneoregon/using-ef-core-and-bogus-246d)
- [Bogus custom Dataset](https://dev.to/karenpayneoregon/bogus-custom-dataset-3h93)

| Package      |   Purpose    |
|:------------- |:-------------|
| [Bogus](https://www.nuget.org/packages/Bogus/35.5.1?_src=template) | For creating mocked data |
| [ConfigurationLibrary](https://www.nuget.org/packages/ConfigurationLibrary/1.0.6?_src=template) | Provides access to appsettings.json for connection strings for three environments, development, testing/staging and production. |
| [EntityCodeFileLogger](https://www.nuget.org/packages/EntityCoreFileLogger/1.0.0?_src=template) | A simple class to log EF Core operations to a text file |