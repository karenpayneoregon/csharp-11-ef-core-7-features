using PeriodicTimerApp.Models;
using Serilog;
using static System.DateTime;

namespace PeriodicTimerApp.Classes;
public class TimerOperations
{
    public delegate void OnShowTime(string sender);
    public static event OnShowTime OnShowTimeHandler;

    public delegate void OnShowContact(Contacts sender);
    public static event OnShowContact OnShowContactHandler;

    /// <summary>
    /// Execute a data read operation every quarter minute to retrieve a random contact.
    /// </summary>
    public static async Task Execute(CancellationToken token)
    {
        static bool IsQuarterMinute()
        {
            var seconds = Now.Second;
            return seconds is 0 or 15 or 30 or 45;
        }

        using PeriodicTimer timer = new(TimeSpan.FromSeconds(1));

        try
        {
            while (await timer.WaitForNextTickAsync(token) && !token.IsCancellationRequested)
            {
                
                OnShowTimeHandler?.Invoke($"Time {Now:hh:mm:ss}");

                if (IsQuarterMinute())
                {
                    Contacts contacts = DapperOperations.Contact();
                    OnShowContactHandler?.Invoke(contacts);
                    EmailOperations.SendEmail(contacts);
                }
            }
        }
        catch (OperationCanceledException) { }
        catch (Exception exception)
        {
            Log.Error(exception,"");
        }
    }


}

