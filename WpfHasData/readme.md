# About

This project was a old [Microsoft sample](https://github.com/dotnet/EntityFramework.Docs/tree/main/samples/core/WPF/GetStartedWPF/GetStartedWPF) upgraded to NET9 to use PayneServiceLibrary for reading connection string and determine if the database should be recreated and populated with static data or data generated from the NuGet package Bogus.

Uses the same models as in SqlServerHasData and SqliteHasData projects.

## Modifications

- Added [SeriLog](https://www.nuget.org/packages/Serilog/4.2.1-dev-02337)
- Added PayneServiceLibrary `local class project`
- [EntityCoreFileLogger](https://www.nuget.org/packages/EntityCoreFileLogger) package