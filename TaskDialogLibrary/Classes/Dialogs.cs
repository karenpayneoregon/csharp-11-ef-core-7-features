// ReSharper disable once CheckNamespace
namespace TaskDialogLibrary;
public partial class Dialogs
{
    // WIP - for showing error text and long error text
    public static void ShowErrorMessage(Control owner, string errorTitle, string instruction, string errorMessage)
    {
        // TODO - finish up

        TaskDialogButton okayButton = new("Okay");
        TaskDialogButtonCollection buttons = new();
        
        TaskDialogPage page = new()
        {
            Caption = "caption",
            SizeToContent = true,
            Heading = errorTitle,
            Expander = new TaskDialogExpander(errorMessage),
            Icon = new TaskDialogIcon(Properties.Resources.agreement),
            Buttons = [okayButton],
            AllowCancel = true
        };

        var result = TaskDialog.ShowDialog(owner, page);

    }
    public static void Information(Control owner, string heading, string text, string buttonText = "Ok")
    {

        TaskDialogButton okayButton = new(buttonText);

        TaskDialogPage page = new()
        {
            Caption = "Information",
            SizeToContent = true,
            Heading = heading,
            Footnote = new TaskDialogFootnote() { Text = "Code sample by Karen Payne" },
            Text = text,
            Icon = new TaskDialogIcon(Properties.Resources.Csharp),
            Buttons = [okayButton],
        };

        TaskDialog.ShowDialog(owner, page);

    }
}
