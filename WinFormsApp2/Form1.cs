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
}
