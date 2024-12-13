using System.ComponentModel;

namespace GlobbingMyDocs.Classes;

public static class ControlExtensions
{
    /// <summary>
    /// Executes the specified action on the control. If the control's thread is different from the
    /// calling thread, the action is invoked on the control's thread using <see cref="ISynchronizeInvoke.Invoke"/>.
    /// </summary>
    /// <typeparam name="T">The type of the control, which must implement <see cref="ISynchronizeInvoke"/>.</typeparam>
    /// <param name="control">The control on which the action is to be executed.</param>
    /// <param name="action">The action to execute on the control.</param>
    /// <remarks>
    /// This method ensures thread-safe interaction with controls by checking if the action needs to be
    /// invoked on the control's thread. If <see cref="ISynchronizeInvoke.InvokeRequired"/> is true, the action
    /// is invoked on the control's thread; otherwise, it is executed directly.
    /// </remarks>
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