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
        try
        {
            var progressIndicator = new Progress<int>(ReportProgress);
            await PerformWork(progressIndicator);
        }
        catch (Exception exception)
        {
            MessageBox.Show($"An error occurred: {exception.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Executes a task asynchronously, reporting progress updates via the provided <see cref="IProgress{T}"/> instance.
    /// </summary>
    /// <param name="progress">
    /// An instance of <see cref="IProgress{T}"/> used to report progress updates. 
    /// The progress value represents the percentage of work completed.
    /// </param>
    private async Task PerformWork(IProgress<int> progress)
    {
        int index = 0;
        int top = 50;

        for (; ; )
        {
            if (index == 100)
            {
                await Task.Delay(100); // Simulate some work
                Controls.Add(new Label() { Parent = this, Text = "Done", Top = top });
                progress?.Report(index);
                break;
            }
            else
            {
                await Task.Delay(1000);
            }

            Controls.Add(new Label() { Parent = this, Text = index.ToString(), Top = top });
            progress?.Report(index);

            index += 10;
            top += 20;
        }
    }

    /// <summary>
    /// Updates the progress bar to reflect the current progress value.
    /// </summary>
    /// <param name="currentValue">
    /// The current progress value, typically representing the percentage of work completed.
    /// </param>
    private void ReportProgress(int currentValue)
    {
        progressBar1.Value = currentValue;
    }


}
