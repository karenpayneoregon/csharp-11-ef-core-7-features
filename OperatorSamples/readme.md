# About

Comparison between explicit operator and implicit operator.

See Microsoft [documentation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators).

A user-defined type can define a custom implicit or explicit conversion from or to another type. Implicit conversions don't require special syntax to be invoked and can occur in various situations, for example, in assignments and methods invocations. Predefined C# implicit conversions always succeed and never throw an exception. User-defined implicit conversions should behave in that way as well. If a custom conversion can throw an exception or lose information, define it as an explicit conversion.

## Model aliasing

Is done in the project file.

```xml
<ItemGroup>
   <Using Include="OperatorSamples.Models1" Alias="M1" />
   <Using Include="OperatorSamples.Models2" Alias="M2" />
</ItemGroup>
```