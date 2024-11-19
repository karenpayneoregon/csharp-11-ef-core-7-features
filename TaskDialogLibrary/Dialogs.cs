#nullable disable

using TaskDialogLibrary.Classes;
using TaskDialogLibrary.Models;
using Timer = System.Windows.Forms.Timer;


namespace TaskDialogLibrary;

/// <summary>
/// Example for using <see cref="TaskDialog"/>
/// </summary>
/// <remarks>
/// - Methods with a parameter for owner will default to centering on owner
///   while without owner parameter will center on the display screen.
/// - IMPORTANT Some methods have Debug.WriteLine and should be removed for use
///   in your projects/applications.
/// </remarks>
public partial class Dialogs
{


    /// <summary>
    /// Dialog to ask a question
    /// </summary>
    /// <param name="caption">text for dialog caption</param>
    /// <param name="heading">text for dialog heading</param>
    /// <param name="yesText">text for yes button</param>
    /// <param name="noText">text for no button</param>
    /// <param name="defaultButton">specifies the default button for this dialog</param>
    /// <returns>true for yes button, false for no button</returns>
    public static bool Question(string caption, string heading, string yesText, string noText, DialogResult defaultButton)
    {

        TaskDialogButton yesButton = new(yesText) { Tag = DialogResult.Yes };
        TaskDialogButton noButton = new(noText) { Tag = DialogResult.No };

        TaskDialogButtonCollection buttons = new();

        if (defaultButton == DialogResult.Yes)
        {
            buttons.Add(yesButton);
            buttons.Add(noButton);
        }
        else
        {
            buttons.Add(noButton);
            buttons.Add(yesButton);
        }

        TaskDialogPage page = new()
        {
            Caption = caption,
            SizeToContent = true,
            Heading = heading,
            Icon = TaskDialogIcon.Information,
            Buttons = buttons
        };


        TaskDialogButton result = TaskDialog.ShowDialog(page);

        return (DialogResult)result.Tag! == DialogResult.Yes;

    }

    /// <summary>
    /// Dialog to ask a question
    /// </summary>
    /// <param name="owner">control or form</param>
    /// <param name="caption">text for dialog caption</param>
    /// <param name="heading">text for dialog heading</param>
    /// <param name="yesText">text for yes button</param>
    /// <param name="noText">text for no button</param>
    /// <param name="defaultButton">specifies the default button for this dialog</param>
    /// <returns>true for yes button, false for no button</returns>
    public static bool Question(Form owner, string caption, string heading, string yesText, string noText, DialogResult defaultButton)
    {

        TaskDialogButton yesButton = new(yesText) { Tag = DialogResult.Yes };
        TaskDialogButton noButton = new(noText) { Tag = DialogResult.No };

        var buttons = new TaskDialogButtonCollection();

        if (defaultButton == DialogResult.Yes)
        {
            buttons.Add(yesButton);
            buttons.Add(noButton);
        }
        else
        {
            buttons.Add(noButton);
            buttons.Add(yesButton);
        }


        TaskDialogPage page = new()
        {
            Caption = caption,
            SizeToContent = true,
            Heading = heading,
            Icon = TaskDialogIcon.Information,
            Buttons = buttons
        };

        var result = TaskDialog.ShowDialog(owner, page);

        return (DialogResult)result.Tag! == DialogResult.Yes;

    }

    /// <summary>
    /// Windows Forms dialog to ask a question
    /// </summary>
    /// <param name="owner">control or form</param>
    /// <param name="heading">text for dialog heading</param>
    /// <param name="icon">Icon to display</param>
    /// <param name="defaultButton">Button to focus</param>
    /// <returns>true for yes button, false for no button</returns>
    public static bool Question(Control owner, string heading, Icon icon, DialogResult defaultButton = DialogResult.Yes)
    {

        TaskDialogButton yesButton = new("Yes") { Tag = DialogResult.Yes };
        TaskDialogButton noButton = new("No") { Tag = DialogResult.No };

        var buttons = new TaskDialogButtonCollection();

        if (defaultButton == DialogResult.Yes)
        {
            buttons.Add(yesButton);
            buttons.Add(noButton);
        }
        else
        {
            buttons.Add(noButton);
            buttons.Add(yesButton);
        }

        TaskDialogPage page = new()
        {
            Caption = "Question",
            SizeToContent = true,
            Heading = heading,
            Icon = new TaskDialogIcon(icon),
            Buttons = buttons
        };

        var result = TaskDialog.ShowDialog(owner, page);

        return (DialogResult)result.Tag! == DialogResult.Yes;

    }

    /// <summary>
    /// Windows Forms dialog to ask a question
    /// </summary>
    /// <param name="owner">control or form</param>
    /// <param name="heading">text for dialog heading</param>
    /// <param name="defaultButton">Button to focus</param>
    /// <returns>true for yes button, false for no button</returns>
    public static bool Question(Control owner, string heading, DialogResult defaultButton = DialogResult.Yes)
    {

        TaskDialogButton yesButton = new("Yes") { Tag = DialogResult.Yes };
        TaskDialogButton noButton = new("No") { Tag = DialogResult.No };
        TaskDialogButtonCollection buttons = new();

        if (defaultButton == DialogResult.Yes)
        {
            buttons.Add(yesButton);
            buttons.Add(noButton);
        }
        else
        {
            buttons.Add(noButton);
            buttons.Add(yesButton);
        }

        TaskDialogPage page = new()
        {
            Caption = "Question",
            SizeToContent = true,
            Heading = heading,
            Icon = new TaskDialogIcon(Properties.Resources.QuestionBlue),
            Buttons = buttons,
            AllowCancel = true
        };

        var result = TaskDialog.ShowDialog(owner, page);

        return result.Tag is not null && (DialogResult)result.Tag == DialogResult.Yes;
    }

    public static (bool yesNo, bool verify) Question(
        Control owner, 
        string heading, 
        string caption, 
        string expandedText, 
        bool verify, 
        DialogResult defaultButton = DialogResult.Yes) {

        TaskDialogButton yesButton = new("Yes") { Tag = DialogResult.Yes };
        TaskDialogButton noButton = new("No") { Tag = DialogResult.No };
        TaskDialogVerificationCheckBox verifyCheckBox = new("Verify");
        TaskDialogButtonCollection buttons = new();

        if (defaultButton == DialogResult.Yes)
        {
            buttons.Add(yesButton);
            buttons.Add(noButton);
        }
        else
        {
            buttons.Add(noButton);
            buttons.Add(yesButton);
        }

        TaskDialogPage page = new()
        {
            Caption = caption,
            SizeToContent = true,
            Heading = heading,
            Expander = new TaskDialogExpander(expandedText),
            Icon = new TaskDialogIcon(Properties.Resources.agreement),
            Buttons = buttons,
            AllowCancel = true
        };

        if (verify)
        {
            page.Verification = verifyCheckBox;
        }
        
        var result = TaskDialog.ShowDialog(owner, page);

        return (result.Tag is not null && (DialogResult)result.Tag == DialogResult.Yes, verifyCheckBox.Checked);
    }

    /// <summary>
    /// Windows Forms dialog to ask a question
    /// </summary>
    /// <param name="owner">control or form</param>
    /// <param name="heading">text for dialog heading</param>
    /// <param name="yesAction">Confirmation action</param>
    /// <param name="noAction">Decline action</param>
    /// <returns>true for yes button, false for no button</returns>
    /// <remarks>
    /// Dialogs.Question(this, "Ask something", YesMethod, NoMethod);
    /// </remarks>
    public static void Question(Control owner, string heading, Action yesAction, Action noAction)
    {

        TaskDialogButton yesButton = new("Yes") { Tag = DialogResult.Yes };
        TaskDialogButton noButton = new("No") { Tag = DialogResult.No };

        var buttons = new TaskDialogButtonCollection
        {
            yesButton,
            noButton
        };

        TaskDialogPage page = new()
        {
            Caption = "Question",
            SizeToContent = true,
            Heading = heading,
            Icon = new TaskDialogIcon(Properties.Resources.QuestionBlue),
            Buttons = buttons
        };

        var result = TaskDialog.ShowDialog(owner, page);

        if ((DialogResult)result.Tag! == DialogResult.Yes)
        {
            yesAction?.Invoke();
        }
        else
        {
            noAction?.Invoke();
        }

    }
    /// <summary>
    /// Windows Forms dialog to ask a question
    /// </summary>
    /// <param name="heading">text for dialog heading</param>
    /// <param name="icon">Icon to display</param>
    /// <param name="defaultButton">Button to focus</param>
    /// <returns>true for yes button, false for no button</returns>
    public static bool Question(string heading, Icon icon, DialogResult defaultButton = DialogResult.Yes)
    {

        TaskDialogButton yesButton = new("Yes") { Tag = DialogResult.Yes };
        TaskDialogButton noButton = new("No") { Tag = DialogResult.No };

        TaskDialogButtonCollection buttons = new();

        if (defaultButton == DialogResult.Yes)
        {
            buttons.Add(yesButton);
            buttons.Add(noButton);
        }
        else
        {
            buttons.Add(noButton);
            buttons.Add(yesButton);
        }

        TaskDialogPage page = new()
        {
            Caption = "Question",
            SizeToContent = true,
            Heading = heading,
            Icon = new TaskDialogIcon(icon),
            Buttons = buttons
        };

        var result = TaskDialog.ShowDialog(page);

        return (DialogResult)result.Tag! == DialogResult.Yes;

    }

    /// <summary>
    /// displays a message with option to assign button text
    /// </summary>
    /// <param name="heading">head for dialog</param>
    /// <param name="buttonText">button text</param>
    public static void Information(string heading, string buttonText = "Ok")
    {

        TaskDialogButton okayButton = new(buttonText);

        TaskDialogPage page = new()
        {
            Caption = "Information",
            SizeToContent = true,
            Heading = heading,
            Icon = new TaskDialogIcon(Properties.Resources.exclamation24),
            Buttons = [okayButton]
        };


        TaskDialog.ShowDialog(page, TaskDialogStartupLocation.CenterScreen);

    }

    /// <summary>
    /// displays a message with option to assign button text
    /// </summary>
    /// <param name="owner">control or form</param>
    /// <param name="heading"></param>
    /// <param name="buttonText"></param>
    public static void Information(Control owner, string heading, string buttonText = "Ok")
    {

        TaskDialogButton okayButton = new(buttonText);

        TaskDialogPage page = new()
        {
            Caption = "Information",
            SizeToContent = true,
            Heading = heading,
            Icon = new TaskDialogIcon(Properties.Resources.Csharp),
            Buttons = [okayButton]
        };

        TaskDialog.ShowDialog(owner, page);

    }

    public static void MsgBox(Control owner, string heading, string buttonText = "Ok")
    {

        TaskDialogButton okayButton = new(buttonText);

        TaskDialogPage page = new()
        {
            Caption = "Information",
            SizeToContent = true,
            Heading = heading,
            Icon = new TaskDialogIcon(Properties.Resources.exclamation24),
            Buttons = [okayButton]
        };


        TaskDialog.ShowDialog(owner, page);

    }

    /// <summary>
    /// Mocked example for showing an auto-close dialog which by not passing parent like the
    /// overloaded version below centers the dialog on the monitor
    /// </summary>
    /// <param name="icon">Icon to display in dialog</param>
    public static void AutoClosingTaskDialog(Icon icon)
    {

        const string textFormat = "Closing in {0} seconds...";
        var remainingTenthSeconds = 30;

        TaskDialogButton continueButton = new("Just do it");
        TaskDialogButton cancelButton = TaskDialogButton.Cancel;

        TaskDialogPage page = new()
        {
            Heading = "Continuing with next process...",
            Text = string.Format(textFormat, (remainingTenthSeconds + 9) / 10),
            Icon = new TaskDialogIcon(icon),
            ProgressBar = new TaskDialogProgressBar() { State = TaskDialogProgressBarState.Paused },
            Buttons = [continueButton, cancelButton],
            Caption = "Auto-close"
        };

        using Timer timer = new()
        {
            Enabled = true,
            Interval = 100
        };

        timer.Tick += ( _ , _ ) =>
        {
            remainingTenthSeconds -= 1;

            if (remainingTenthSeconds > 0)
            {
                page.Text = string.Format(textFormat, (remainingTenthSeconds + 9) / 10);
                page.ProgressBar.Value = 100 - remainingTenthSeconds * 2;
            }
            else
            {
                timer.Enabled = false;

                if (continueButton.BoundPage is not null)
                {
                    continueButton.PerformClick();
                }

            }
        };

        TaskDialogButton result = TaskDialog.ShowDialog(page);

        ContinueOperation?.Invoke(result == continueButton);

    }

    /// <summary>
    /// Mocked example for showing a auto-close dialog which by passing the parent control
    /// will be default display this dialog centered on the parent control.
    /// </summary>
    /// <param name="owner">control or form</param>
    /// <param name="Icon">Icon to display in dialog</param>
    public static void AutoClosingTaskDialog(Control owner, Icon Icon)
    {

        const string textFormat = "Closing in {0} seconds...";
        var remainingTenthSeconds = 50;

        TaskDialogButton continueButton = new("Just do it");
        TaskDialogButton cancelButton = TaskDialogButton.Cancel;

        // Display the form's icon in the task dialog.
        // Note however that the task dialog will not scale the icon.
        TaskDialogPage page = new()
        {
            Heading = "Continuing with next process...",
            Text = string.Format(textFormat, (remainingTenthSeconds + 9) / 10),
            Icon = new TaskDialogIcon(Icon),
            ProgressBar = new TaskDialogProgressBar() { State = TaskDialogProgressBarState.Paused },
            Buttons = [continueButton, cancelButton],
            Caption = "Auto-close"
        };

        using Timer timer = new()
        {
            Enabled = true,
            Interval = 100
        };

        timer.Tick += (_, _) =>
        {
            remainingTenthSeconds -= 1;

            if (remainingTenthSeconds > 0)
            {
                page.Text = string.Format(textFormat, (remainingTenthSeconds + 9) / 10);
                page.ProgressBar.Value = 100 - remainingTenthSeconds * 2;
            }
            else
            {
                timer.Enabled = false;

                if (continueButton.BoundPage is not null)
                {
                    continueButton.PerformClick();
                }
            }
        };

        TaskDialogButton result = TaskDialog.ShowDialog(owner, page);

        ContinueOperation?.Invoke(result == continueButton);
    }


    /// <summary>
    /// Displays a task dialog that automatically closes after a specified number of seconds.
    /// </summary>
    /// <param name="owner">The control that owns this dialog.</param>
    /// <param name="text">The main text to display in the dialog.</param>
    /// <param name="header">The header text to display in the dialog.</param>
    /// <param name="seconds">The number of seconds before the dialog automatically closes.</param>
    /// <param name="okText">The text for the OK button. Defaults to "OK".</param>
    public static void AutoCloseDialog(Control owner, string text, string header, int seconds, string okText = "OK")
    {

        var remaining = seconds * 10;

        TaskDialogButton continueButton = new(okText);

        TaskDialogPage page = new()
        {
            Heading = header,
            Text = text,
            Icon = new TaskDialogIcon(Properties.Resources.csharp1),
            Buttons = [continueButton],
            Caption = "Auto-close"
        };

        using Timer timer = new()
        {
            Enabled = true,
            Interval = 100
        };

        timer.Tick += (_, _) =>
        {
            remaining -= 1;

            if (remaining != 0) return;
            timer.Enabled = false;
            if (continueButton.BoundPage is not null)
            {
                continueButton.PerformClick();
            }
        };

        var result = TaskDialog.ShowDialog(owner, page);

        ContinueOperation?.Invoke(result == continueButton);

    }
 
    /// <summary>
    /// Used for development to display exception information
    /// </summary>
    /// <param name="exception">Exception thrown</param>
    /// <param name="buttonText">optional text for button</param>
    public static void ErrorBox(Exception exception, string buttonText = "Silly programmer")
    {

        TaskDialogButton singleButton = new(buttonText);

        var text = $"Encountered the following{Environment.NewLine}{exception.Message}";


        TaskDialogPage page = new()
        {
            Caption = "Information",
            SizeToContent = true,
            Heading = text,
            Icon = TaskDialogIcon.Error,
            Buttons = [singleButton]
        };

        TaskDialog.ShowDialog(page);

    }

    public static void ErrorBox(Form owner, Exception exception, string buttonText = "Dang")
    {

        TaskDialogButton singleButton = new(buttonText);

        var text = $"Encountered the following{Environment.NewLine}{exception.Message}";


        TaskDialogPage page = new()
        {
            Caption = "Information",
            SizeToContent = true,
            Heading = text,
            Icon = TaskDialogIcon.Error,
            Buttons = [singleButton]
        };

        TaskDialog.ShowDialog(owner,page);

    }

    /// <summary>
    /// A dialog with option to not display again
    /// </summary>
    /// <param name="owner">exist control or form</param>
    /// <param name="options"><seealso cref="ShowAgainOptions"/></param>
    /// <returns><seealso cref="NoShowResult"/></returns>
    public static (NoShowResult DialogResult, bool showAgain) DoNotShowAgain(Control owner, ShowAgainOptions options)
    {

        TaskDialogPage page = new()
        {
            Heading = options.Heading,
            Text = options.Text,
            Caption = options.Caption,
            Icon = new TaskDialogIcon(options.Icon),
            AllowCancel = true,
            Verification = new TaskDialogVerificationCheckBox()
            {
                Text = options.VerificationText
            },
            Buttons = [TaskDialogButton.Yes, TaskDialogButton.No],
            DefaultButton = TaskDialogButton.No
        };

        if (TaskDialog.ShowDialog(owner, page) == TaskDialogButton.Yes)
        {

            bool showAgain = false;

            if (page.Verification.Checked)
            {
                SettingOperations.SetShowAgain(false);
                showAgain = false;
            }
            else
            {
                SettingOperations.SetShowAgain(true);
                showAgain = true;
            }

            return (NoShowResult.StopOperation, showAgain);

        }
        else
        {

            return (NoShowResult.No, true);

        }

    }


    public delegate void OnContinue(bool sender);
#pragma warning disable CS8618
    public static event OnContinue ContinueOperation;
#pragma warning restore CS8618

}