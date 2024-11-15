# About

Playground for C#13

- Partial properties
- [params collections](https://devblogs.microsoft.com/dotnet/csharp13-calling-methods-is-easier-and-faster/)
- Index() deconstruct
- ShowDialogAsync
- [Darkmode](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/whats-new/net90?view=netdesktop-9.0#dark-mode)


## Notes

- Ran the following command
```
dotnet list package --vulnerable --include-transitive
```

- Project file mods

```xml
<ItemGroup>
  <NuGetAuditSuppress Include="https://github.com/advisories/GHSA-hh2w-p6rv-4g7w" />
  <NuGetAuditSuppress Include="https://github.com/advisories/GHSA-8g4q-xg66-9fp4" />
</ItemGroup>

<!-- for ShowDialogAsync-->
<PropertyGroup>
  <NoWarn>$(NoWarn);WFO5002</NoWarn>
</PropertyGroup>
```

- `[Experimental("WFO5002")]` for `ShowDialogAsync`

---
## Field keyword

> **Note**
> The `field` keyword is a preview feature in C# 13.

Requires the following in .csproj

```xml
<LangVersion>preview</LangVersion>
```
