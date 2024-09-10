namespace WinFormsApp1;
public partial class ChildForm : Form
{
    public delegate void OnBaggage(Baggage sender);
    public event OnBaggage SendBaggage;
    public int Value { get; set; }
    public ChildForm()
    {
        InitializeComponent();
    }
    public ChildForm(int value)
    {
        InitializeComponent();

        numericUpDown1.Minimum = 1;
        Value = value;
        CurrentValueLabel.Text = $"Current value: {Value}";
    }
    private void ExecuteButton_Click(object sender, EventArgs e)
    {
        // consider validation e.g. if value is less than 1
        Baggage baggage = new()
        {
            Add = AddCheckBox.Checked,
            Value = AddCheckBox.Checked ? Value += (int)numericUpDown1.Value : Value -= (int)numericUpDown1.Value
        };

        SendBaggage?.Invoke(baggage);
        DialogResult = DialogResult.OK;

    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }
}
