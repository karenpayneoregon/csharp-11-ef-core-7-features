
using NativeValidatorsSamples.Classes;
using static TaskDialogLibrary.Dialogs;

namespace NativeValidatorsSamples;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void IntegerValidatorButton_Click(object sender, EventArgs e)
    {
        Examples.IntegerValidator();
        Information(this, "See output window for details.");
    }

    private void TimeSpanValidatorButton_Click(object sender, EventArgs e)
    {
        Examples.TimeSpanValidator();
        Information(this, "See output window for details.");

    }
}
