using System.Diagnostics.CodeAnalysis;
using WinFormsSystemColorModeLibrary;

namespace WinFormsAsync
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        [Experimental("WFO5001")]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.SetColorMode(Configuration.Instance.ColorMode);
            ApplicationConfiguration.Initialize();
            //Application.SetColorMode(SystemColorMode.System);
            Application.Run(new TimerForm());
        }
    }
}
