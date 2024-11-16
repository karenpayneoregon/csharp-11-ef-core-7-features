# About 

Provides code to implement dark mode for a Windows Form project.

## Instructions

Add the following to `Program.cs` before `Application.Run`.

```csharp
Application.SetColorMode(Configuration.Instance.ColorMode);
```

Note in project file, the following is needed as per [Microsoft docs](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/whats-new/net90?view=netdesktop-9.0#dark-mode).

```xml
<PropertyGroup>
   <NoWarn>$(NoWarn);WFO5001</NoWarn>
</PropertyGroup>
```

As coded in KP_WindowsFormsNET9, appsettings.json has two sections that the reader does not need left there to allow a developer to see what is needed for the update code.


## Article

https://dev.to/karenpayneoregon/window-forms-dark-mode-33on