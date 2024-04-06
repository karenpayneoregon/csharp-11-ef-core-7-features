using PeriodicTimerWebApp.Models;
using Serilog;

namespace PeriodicTimerWebApp.Classes;

public class TimerOperations : IAsyncDisposable
{

    PeriodicTimer _timer;
    Task _timerTask;
    CancellationTokenSource _cts;
    public string ConnectionString { get; set; }

    public delegate void OnShowContact(Contacts sender);
    public event OnShowContact OnShowContactHandler;
    public TimerOperations()
    {
        _cts = new CancellationTokenSource();

        _timer = new PeriodicTimer(TimeSpan.FromSeconds(5));
        _timerTask = ExecuteAsync(_timer, _cts.Token);
    }

    public void Cancel() => _cts.Cancel();

    async Task ExecuteAsync(PeriodicTimer timer, CancellationToken cancel = default)
    {
        try
        {
            while (await timer.WaitForNextTickAsync(cancel))
            {
                await Task.Run(async () => await PerformWork(cancel)!, cancel);
            }
        }
        catch (Exception exception)
        {
            Log.Error(exception,"");
        }

    }

    private Task? PerformWork(CancellationToken cancel)
    {
        if (ConnectionString is not null)
        {
            DapperOperations dapperOperations = new DapperOperations(ConnectionString);
            var contact = dapperOperations.Contact();
            OnShowContactHandler?.Invoke(contact);
            Log.Information("Contact: {P1} {P2}", contact.FirstName, contact.LastName);
        }

        return Task.CompletedTask;
    }

    public async ValueTask DisposeAsync()
    {
        _timer.Dispose();
        await _timerTask;
        GC.SuppressFinalize(this);
    }
}
