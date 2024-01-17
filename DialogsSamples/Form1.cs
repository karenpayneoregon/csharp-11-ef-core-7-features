using static DialogsCoreLibrary.Dialogs;

namespace DialogsSamples;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void QuestionButton1_Click(object sender, EventArgs e)
    {
        MessageBox.Show(Question(this, "Question", "Are you using C#12") ? "Cool" : "Might want to upgrade");
    }

    private void QuestionButton2_Click(object sender, EventArgs e)
    {
        MessageBox.Show(Question(QuestionButton2, "Question", "Do you use VB.NET?", "Yes", "Nope", DialogResult.Yes) ? "Cool" : "C# developer.");
    }
}
