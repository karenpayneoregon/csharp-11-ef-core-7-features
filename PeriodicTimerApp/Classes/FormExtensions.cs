using System.ComponentModel;

namespace PeriodicTimerApp.Classes;

public static class FormExtensions
{
    public static void InvokeIfRequired<T>(this T control, Action<T> action) where T : ISynchronizeInvoke
    {
        if (control.InvokeRequired)
        {
            control.Invoke(new Action(() => action(control)), null);
        }
        else
        {
            action(control);
        }
    }
}