# About

Example for using [field backed property](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/field) (which is in preview currently), INotifyPropertyChanged and partial class.

Partial class is used to separate the generated code from the code for INotifyPropertyChanged.

[Partial property](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-13.0/partial-properties) example for `Remarks` property defining declaration is in the main `Person` class and the implementing declaration is in the `PersonOther.cs` file.

Everything presented can be used in other project types such as Blazor, ASP.NET Core etc.

## Project file

`<LangVersion>preview</LangVersion>` is required for fields.

There is an **ItemGroup** for `NuGetAuditSuppress` for `System.Text.Json` vunerablity which hopefully gets an update soon.