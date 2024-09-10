namespace WinFormsApp1;
public partial class MainForm : Form
{
    // could come a database or another source
    private int SomeValue { get; set; } = 1;
    public MainForm()
    {
        InitializeComponent();
        CurrentValueLabel.Text = $"Current value: {SomeValue}";
    }

    private void ShowChildForm1_Click(object sender, EventArgs e)
    {
        using ChildForm form = new(SomeValue);
        form.SendBaggage += Form_SendBaggage;
        form.ShowDialog();
    }

    private void Form_SendBaggage(Baggage sender)
    {
        SomeValue = sender.Value;
        CurrentValueLabel.Text = $"Current value: {SomeValue}";
        OperationTypeLabel.Text = sender.Add ? "Added" : "Subtracted";
    }
}

public class Baggage
{
    public bool Add { get; set; }
    public int Value { get; set; }
}