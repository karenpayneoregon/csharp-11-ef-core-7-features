# About


Allow using alias directive to reference any kind of Type. Alias any type is a feature that allows you to use the using alias directive to create a new name for any type, not just named types.

In the project, in Stuff.cs

```csharp
global using FileExist = bool;
global using DirectoryExist = bool;
global using CurrentUserFileList = System.Collections.Generic.List<string?>;
```

- The first two alias to bool that when used in code can make sense that bool along
- The first, alias List&lt;string> for collecting files from a folder.

For this to work, in the project file, `ImplicitUsings` must be set to `enable`.

```xml
<ImplicitUsings>enable</ImplicitUsings>
```