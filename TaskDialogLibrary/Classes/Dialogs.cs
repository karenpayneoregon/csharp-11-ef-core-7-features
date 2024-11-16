// ReSharper disable once CheckNamespace
namespace TaskDialogLibrary;
public partial class Dialogs
{
    public static bool Question(Control owner, string caption, string text, string yesText, string noText, DialogResult defaultButton)
    {
        TaskDialogButtonCollection buttons = defaultButton == DialogResult.Yes ? YesButtonFirst(yesText, noText) : NoButtonFirst(noText, yesText);
        TaskDialogPage page = new()
        {
            Caption = caption,
            SizeToContent = true,
            Heading = text,
            Icon = new TaskDialogIcon(Properties.Resources.question32),
            Buttons = buttons
        };

        var result = TaskDialog.ShowDialog(owner, page);
        return (DialogResult)result.Tag! == DialogResult.Yes;
    }
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

    public static void Restart(Control owner)
    {

        TaskDialogButton okayButton = new("Restart");

        TaskDialogPage page = new()
        {
            Caption = "Information",
            SizeToContent = true,
            Text = "Must restart for changes to take affect.",
            Icon = new TaskDialogIcon(Properties.Resources.Csharp),
            Buttons = [okayButton],
        };

        TaskDialog.ShowDialog(owner, page);

    }

    private static TaskDialogButtonCollection YesButtonFirst(string yesText, string noText)
        => [new TaskDialogButton(yesText) { Tag = DialogResult.Yes }, new TaskDialogButton(noText) { Tag = DialogResult.No }];

    private static TaskDialogButtonCollection NoButtonFirst(string yesText, string noText)
        => [new TaskDialogButton(noText) { Tag = DialogResult.No }, new TaskDialogButton(yesText) { Tag = DialogResult.Yes }];
}
