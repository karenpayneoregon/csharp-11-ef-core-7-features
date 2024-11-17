using WinFormsSystemColorModeLibrary;

namespace DarkModeApp;


#pragma warning disable WFO5001

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        /*
         * See https://learn.microsoft.com/en-us/dotnet/desktop/winforms/whats-new/net90?view=netdesktop-9.0#dark-mode
         */

        Application.SetColorMode(Configuration.Instance.ColorMode);
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());

    }
}