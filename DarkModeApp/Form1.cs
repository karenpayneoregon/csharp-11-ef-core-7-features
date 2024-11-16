using DarkModeApp.Classes;
using WinFormsSystemColorModeLibrary;
using static System.Globalization.DateTimeFormatInfo;

namespace DarkModeApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        dataGridView1.DataSource = BogusOperations.CustomersList(20);
        dataGridView1.ExpandColumns();

        if (Configuration.Instance.IsDarkMode)
        {
            dataGridView1.ColorizeDarkModeHeaders();
        }

        MonthComboBox.DataSource = CurrentInfo.MonthNames[..^1];
    }

    private void CloseAppButton_Click(object sender, EventArgs e)
    {
        Close();
    }
}
