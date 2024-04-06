using PeriodicTimerApp.Classes;
using PeriodicTimerApp.Models;
using WinFormsApp1.Classes;

namespace PeriodicTimerApp;
public partial class PeriodicTimerForm : Form
{
    private CancellationTokenSource cts = new();

    public PeriodicTimerForm()
    {
        InitializeComponent();

        ContactNameLabel.Text = "";

        TimerOperations.OnShowTimeHandler += ShowTime;
        TimerOperations.OnShowContactHandler += ShowContact;
        Closing += (sender, args) => cts.Dispose();

        Shown += PeriodicTimerForm_Shown;
    }

    private async void PeriodicTimerForm_Shown(object? sender, EventArgs e)
    {
        await Start();
    }

    private void ShowContact(Contacts contact)
    {
        ContactNameLabel.Text = $"{contact.FirstName} {contact.LastName}";
    }

    private void ShowTime(string sender)
    {
        ShowTimeLabel.InvokeIfRequired(label => { label.Text = sender; });
    }

    private async void StartButton_Click(object sender, EventArgs e)
    {
        await Start();
    }

    private async Task Start()
    {
        StartButton.Enabled = false;
        ContactNameLabel.Text = "";

        if (cts.IsCancellationRequested)
        {
            cts.Dispose();
            cts = new CancellationTokenSource();
        }

        await TimerOperations.Execute(cts.Token);
    }

    private void StopButton_Click(object sender, EventArgs e)
    {
        cts.Cancel();
        StartButton.Enabled = true;
        Dialogs.Information(this, "","Cancelled");
    }
    
}