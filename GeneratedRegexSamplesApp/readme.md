﻿# About

Exposing the regex samples generated by the [GeneratedRegex](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.generatedregexattribute?view=net-8.0) attribute which in many cases when using regular expressions the generated code will explain the regular expressions.

One exception is `RegularExpressionHelpers.SSNValidationRegex();` which does document but does not explain the regular expression as to the meaning of the regular expression which is done manually.


## Instructions

Add the following to the project file

```xml
<PropertyGroup>
  <EmitCompilerGeneratedFiles>true</EmitCompilerGeneratedFiles>
  <CompilerGeneratedFilesOutputPath>Generated</CompilerGeneratedFilesOutputPath>
</PropertyGroup>
```

Build the project and navigate to the `Generated` folder to find the generated files.

Now traverse to the file under the `Generated` folder and select properties and set `Build Action` to `None`.

When done examining the generated files, comment out the msbuild group above so that the code does not get added to source.

If desired add the following to the project file to remove the generated files.

```xml
<ItemGroup>
   <Compile Remove="$(CompilerGeneratedFilesOutputPath)/**/*.cs" />
</ItemGroup>
```

## Article

WIP
