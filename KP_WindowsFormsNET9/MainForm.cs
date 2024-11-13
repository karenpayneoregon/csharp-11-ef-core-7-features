
using System.Diagnostics.CodeAnalysis;

namespace KP_WindowsFormsNET9;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    [Experimental("WFO5002")]
    private async void ShowFormButton_Click(object sender, EventArgs e)
    {
        ChildForm childForm = new();
        await childForm.ShowDialogAsync();
    }
}

