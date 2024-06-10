# About

This project demonstrates using Bogus to mockup data for `SQL-Server database`, converts enumerations and has a computed column on a date column using a DateOnly column to get a person’s years old using `EF Core 8`.

- Database and tables are created using Entity Framework Core HasData in the DbContext using [Bogus](https://www.nuget.org/packages/Bogus) NuGet package.
- Mocked data is the same for each run as per using Bogus [Seed](https://github.com/bchavez/Bogus?tab=readme-ov-file#the-great-c-example).
- For the most part gender matches first name, but there are some exceptions so there are no guaranteed but for the project they are correct.

![Title](assets/title.png)