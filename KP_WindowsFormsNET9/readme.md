# About

Playground for C# 13

- Partial properties
- Index() deconstruct
- ShowDialogAsync


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
