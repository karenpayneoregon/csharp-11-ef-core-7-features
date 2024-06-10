using System.Diagnostics;
using WinFormsApp2.Classes;

namespace WinFormsApp2;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void selectCustomerButton_Click(object sender, EventArgs e)
    {
        using var f = new CustomerSelectForm();
        CustomerSelectForm.CustomerSelected += CustomerSelected;
        f.ShowDialog();
        CustomerSelectForm.CustomerSelected -= CustomerSelected;
    }

    private void CustomerSelected(Models.Customer sender)
    {
        // populate the textboxes
    }



    private void revealPasswordButton_MouseDown(object sender, MouseEventArgs e)
    {
        passwordTextBox.ToggleShow();
    }

    private void revealPasswordButton_MouseUp(object sender, MouseEventArgs e)
    {
        passwordTextBox.ToggleShow(false);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        passwordTextBox.ToggleShow(false);
    }
}
