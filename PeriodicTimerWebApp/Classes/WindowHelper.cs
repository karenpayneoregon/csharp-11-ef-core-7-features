using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PeriodicTimerWebApp.Classes;
/// <summary>
/// Taken from my personal class project
/// </summary>
public static class WindowHelper
{

    public static void BringProcessToFront(Process process)
    {
        IntPtr handle = process.MainWindowHandle;
        if (IsIconic(handle))
        {
            ShowWindow(handle, SwRestore);
        }

        SetForegroundWindow(handle);
    }

    /// <summary>
    /// <para>Locates the console window for a web application started with Visual Studio.</para>
    /// <para>If not in production environment bring the window to the front.</para>
    /// </summary>
    /// <param name="app">The application</param>
    /// <param name="title">Optional title for console window</param>
    public static void ShowConsoleWindow(WebApplication app, string title = "")
    {
        if (!app.Environment.IsDevelopment())
        {
            return;
        }

        Process[] processes = Process.GetProcesses();

        var consoleWindowTitle = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
            string.Concat(AppDomain.CurrentDomain.FriendlyName, ".exe"));
        
        foreach (var process in processes)
        {
            if (string.IsNullOrWhiteSpace(process.MainWindowTitle)) continue;
            if (process.MainWindowTitle == consoleWindowTitle)
            {
                BringProcessToFront(process);
                
                if (!string.IsNullOrWhiteSpace(title))
                {
                    SetWindowText(process.MainWindowHandle, title);
                }
            }
        }
    }

    public static void SetConsoleWindowTitle(this WebApplication app, string title)
    {
        if (!app.Environment.IsDevelopment())
        {
            return;
        }

        Process[] processes = Process.GetProcesses();

        var consoleWindowTitle = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            string.Concat(AppDomain.CurrentDomain.FriendlyName, ".exe"));
        var p = processes.FirstOrDefault(x => x.MainWindowTitle == consoleWindowTitle);
        SetWindowText(p.MainWindowHandle, title);
      
    }

    const int SwRestore = 9;

    [DllImport("User32.dll")]
    private static extern bool SetForegroundWindow(IntPtr handle);
    [DllImport("User32.dll")]
    private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
    [DllImport("User32.dll")]
    private static extern bool IsIconic(IntPtr handle);
    [DllImport("user32.dll")]
    static extern int SetWindowText(IntPtr hWnd, string text);
}
