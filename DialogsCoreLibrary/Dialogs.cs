namespace DialogsCoreLibrary;

    public class Dialogs
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
        public static bool Question(Control owner, string caption, string text, DialogResult defaultButton = DialogResult.No)
        {
            TaskDialogButtonCollection buttons = defaultButton == DialogResult.Yes ? YesButtonFirst("No", "Yes") : NoButtonFirst("Yes", "No");
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

        private static TaskDialogButtonCollection YesButtonFirst(string yesText, string noText) 
            => [ new TaskDialogButton(yesText) { Tag = DialogResult.Yes }, new TaskDialogButton(noText) { Tag = DialogResult.No } ];

        private static TaskDialogButtonCollection NoButtonFirst(string yesText, string noText) 
            => [ new TaskDialogButton(noText) { Tag = DialogResult.No }, new TaskDialogButton(yesText) { Tag = DialogResult.Yes } ];
    }


