namespace KP_WindowsFormsNET9.Classes;

    public class Dialogs
    {

        /// <summary>
        /// Displays an information dialog with a specified heading, text, and button text.
        /// </summary>
        /// <param name="owner">The control that owns the dialog.</param>
        /// <param name="heading">The heading text of the dialog.</param>
        /// <param name="text">The main content text of the dialog.</param>
        /// <param name="buttonText">The text displayed on the button. Defaults to "Ok".</param>
        /// <remarks>
        /// Usually the Icon would come from resources but currently having issues with Resources
        /// Also does not respect dark mode.
        /// </remarks>
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
                Icon = new TaskDialogIcon(new Bitmap("blueInformation_32.ico")),
                Buttons = [okayButton],
            };

            TaskDialog.ShowDialog(owner, page);

        }
}


