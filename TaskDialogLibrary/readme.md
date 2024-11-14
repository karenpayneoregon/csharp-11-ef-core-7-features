# .NET Core 6 TaskDialog

When an application requires a message to be display or to ask a user questions the common method is to use a [MessageBox](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox?view=windowsdesktop-6.0).

A standard message box with its many overloads for Show method is fine for simply displaying and asking for input (without a input/textbox) while the TaskDialog provides more flexibilities. With these flexibilities comes more code which can be placed into a separate class in a project or better, place code into a separate class project. To use the class project, add a reference to a project or create a NuGet local package and install the package in any project.

Include are several methods to ask a question, display information and a dialog to ask a question with a time-out.

For full documentation see the following [repository](https://github.com/karenpayneoregon/task-dialog-csharp) which has many more examples which were not placed here to keep this library simple.
