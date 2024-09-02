namespace IProgressApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Shown += Form1_Shown;
    }

    private async void Form1_Shown(object? sender, EventArgs e)
    {
        var progressIndicator = new Progress<int>(ReportProgress);
        try
        {
            await PerformWork(progressIndicator);
        }
        catch (Exception exception)
        {
            // TODO
        }
    }

    private async Task PerformWork(IProgress<int> progress)
    {
        int index = 0;
        int top = 50;

        for (; ; )
        {
            if (index == 100)
            {
                await Task.Delay(100); // Simulate some work
                Controls.Add(new Label() { Parent = this, Text ="Done", Top = top });
                progress?.Report(index);
                break;
            }

            Controls.Add(new Label() { Parent = this, Text = index.ToString(), Top = top });
            progress?.Report(index);

            index += 10;
            top += 20;
        }
    }

    private void ReportProgress(int currentValue)
    {
        progressBar1.Value = currentValue;
    }


}
