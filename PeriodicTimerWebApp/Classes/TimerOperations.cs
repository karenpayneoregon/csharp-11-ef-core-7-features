using Serilog;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace PeriodicTimerWebApp.Classes;

public class TimerOperations : IAsyncDisposable
{

    PeriodicTimer _timer;
    Task _timerTask;
    CancellationTokenSource _cts;
    public string ConnectionString { get; set; }

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
            DapperOperations dapperOperations = new(ConnectionString);
            var contact = dapperOperations.Contact();
            EmailOperations.SendEmail(contact);
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

