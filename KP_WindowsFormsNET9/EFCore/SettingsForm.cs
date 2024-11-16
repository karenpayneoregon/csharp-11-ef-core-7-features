using KP_WindowsFormsNET9.Classes.Configuration;

using static TaskDialogLibrary.Dialogs;

namespace KP_WindowsFormsNET9.EFCore;
public partial class SettingsForm : Form
{
    public SettingsForm()
    {
        InitializeComponent();

        // set combobox datasource followed by setting the selected index
        ModeComboBox.DataSource = Configuration.Instance.ModesArray;
        var index = Array.IndexOf(Configuration.Instance.ModesArray, Configuration.Instance.ColorMode.ToString());
        ModeComboBox.SelectedIndex = index;
    }

    /// <summary>
    /// Updates the application's color mode based on the selected value from the ModeComboBox.
    /// If the selected mode is different from the current mode, prompts the user to restart the application
    /// for the changes to take effect.
    /// </summary>
    private void ChangeButton_Click(object sender, EventArgs e)
    {
        var selected = ModeComboBox.Text;

        if (Configuration.Instance.ColorMode == Enum.Parse<SystemColorMode>(selected))
        {
            DialogResult = DialogResult.Cancel;
        }
        else
        {
            Configuration.Instance.ColorMode = Enum.Parse<SystemColorMode>(selected);
            Configuration.Instance.SetModeText(Configuration.Instance.ColorMode);
            if (Question(this, "Alert", "Must restart for changes to take affect", "Yes please", "Nope", DialogResult.No))
            {
                Application.Restart();
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }



    }
}
