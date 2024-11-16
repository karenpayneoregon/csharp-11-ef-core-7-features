using KP_WindowsFormsNET9.Classes.Configuration;

namespace KP_WindowsFormsNET9;
public partial class ChildForm : Form
{
    public ChildForm()
    {
        InitializeComponent();

        // SolidBrush
        Text = Configuration.Instance.IsDarkMode ? "Dark Mode" : "Light Mode";
    }
}
