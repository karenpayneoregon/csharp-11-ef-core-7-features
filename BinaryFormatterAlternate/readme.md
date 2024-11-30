# About

This project provides an alternative implementation of the BinaryFormatter class that is used to serialize objects in .NET. The goal is to provide a more secure implementation that is not vulnerable to the well-known BinaryFormatter security issues.

All code samples allow a developer to make an informed decision on which path to take.

## Notes

- Exception handling is omitted for brevity.
- No encryption is used in the examples as each developer will have different requirements. One idea is [Inferno](https://www.nuget.org/packages/Inferno/1.6.6?_src=template) NuGet package and [documentation](https://securitydriven.net/inferno/). See `InfernoOperations` class which encrypts and decrypts an existing json file. Make sure to read the class documentation.

## Microsoft docs

BinaryFormatter [migration guide](https://learn.microsoft.com/en-us/dotnet/standard/serialization/binaryformatter-migration-guide/)
