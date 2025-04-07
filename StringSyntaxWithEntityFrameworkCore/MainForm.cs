using StringSyntaxWithEntityFrameworkCore.Classes;
using StringSyntaxWithEntityFrameworkCore.Classes.Configuration;
// ReSharper disable AsyncVoidMethod

namespace StringSyntaxWithEntityFrameworkCore;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Calls the Conventional method from the Samples class asynchronously.
    /// </summary>
    private async void ConventionalButton_Click(object sender, EventArgs e)
    {
        await Samples.Conventional();
    }

    /// <summary>
    /// Calls the Syntax method from the Samples class asynchronously with the specified parameters.
    /// </summary>
    private async void ChoiceButton_Click(object sender, EventArgs e)
    {
        await Samples.Syntax("D2", "MM/dd/yyyy", "D3");
    }

    /// <summary>
    /// Creates a new instance of the Samples class and calls the KarenSyntax method asynchronously.
    /// </summary>
    private async void FromSettingsButton_Click(object sender, EventArgs e)
    {
        var ops = new Samples();
        await ops.SpecialSyntax();
    }
}
