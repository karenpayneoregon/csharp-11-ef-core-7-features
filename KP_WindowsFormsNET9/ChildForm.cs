using KP_WindowsFormsNET9.Classes.Configuration;

namespace KP_WindowsFormsNET9;
public partial class ChildForm : Form
{
    public ChildForm()
    {
        InitializeComponent();

        Text = Configuration.Instance.ModeText;
    }
}
