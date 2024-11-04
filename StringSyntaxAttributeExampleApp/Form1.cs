using System.Diagnostics;
using StringSyntaxAttributeExampleApp.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using StringTokenFormatter;

namespace StringSyntaxAttributeExampleApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void DateFormatButton_Click(object sender, EventArgs e)
    {
        Operations.SetDateFormat("D", [1, 2, 3]);
    }

    private void NumberFormatButton_Click(object sender, EventArgs e)
    {
        Operations.SetNumberFormat("D2");
    }

    private void CompositeFormatButton_Click(object sender, EventArgs e)
    {

        Customer customer = new()
        {
            FirstName = "Karen",
            LastName = "Payne",
            Title = "Ms",
            Age = 68,
            IsFirstOrder = false,
        };

        Debug.WriteLine(Operations.CompositeFormat(customer, "First Name {0,-14} Last name {1,-10} Age {2}"));

    }

    // https://github.com/andywilsonuk/StringTokenFormatter
    private void button1_Click(object sender, EventArgs e)
    {
        Operations.Demo();
        
    }
}


