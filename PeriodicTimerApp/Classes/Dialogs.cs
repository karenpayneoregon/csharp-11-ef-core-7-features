using PeriodicTimerApp.Properties;

namespace WinFormsApp1.Classes;

/// <summary>
/// Custom dialogs
/// </summary>
/// <remarks>
/// Both use images from project resources, with standard images
/// the dialog emits a beep.
/// </remarks>
public class Dialogs
{

    /// <summary>
    /// Information dialog centered to an owner
    /// </summary>
    /// <param name="owner">Control or form to center on</param>
    /// <param name="heading">Heading text or an empty string</param>
    /// <param name="text">Text to display</param>
    /// <param name="buttonText">To override OK as the button text</param>
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
            Icon = new TaskDialogIcon(Resources.blueInformation_32),
            Buttons = [okayButton]
        };

        TaskDialog.ShowDialog(owner, page);

    }

}
