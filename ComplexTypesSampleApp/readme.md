# About

This sample app demonstrates how to use the [Complex Types](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/whatsnew#value-objects-using-complex-types) API to create, read, update complex types.

The code was taken from this repository [project](https://github.com/dotnet/EntityFramework.Docs/tree/main/samples/core/Miscellaneous/NewInEFCore8) and modified for the reader to learn from even though the original code is easy to follow but was generic to suite several different ways of writing the code.

- Connection string is read from appsettings.json
    - Currently set to create Karen1 database under localdb, might want to change the name
- EF Core logs to a file under the application folder
