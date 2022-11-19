# About

Example for [ISingletonInterceptor](https://github.com/dotnet/efcore/blob/main/src/EFCore/Diagnostics/IMaterializationInterceptor.cs) from What's New in EF Core 7.0 section [Simple actions on entity creation](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-7.0/whatsnew#simple-actions-on-entity-creation)

The new IMaterializationInterceptor supports interception before and after an entity instance is created, and before and after properties of that instance are initialized. The interceptor can change or replace the entity instance at each point.

This code sample follows the section above to retrieve the date time when a record was read.

