using KP_WindowsFormsNET9.Classes.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KP_WindowsFormsNET9;
internal static class Program
{

    [STAThread]
    static async Task Main()
    {
        ApplicationConfiguration.Initialize();

        await Setup();

        /*
         * See https://learn.microsoft.com/en-us/dotnet/desktop/winforms/whats-new/net90?view=netdesktop-9.0#dark-mode
         */
        Application.SetColorMode(Configuration.Instance.ColorMode);
        Application.Run(new MainForm());
    }

    /// <summary>
    /// Setup for reading connection strings and entity settings from appsettings.json
    /// </summary>
    private static async Task Setup()
    {
        var services = Classes.Configuration.ApplicationConfiguration.ConfigureServices();
        await using var serviceProvider = services.BuildServiceProvider();
        serviceProvider.GetService<SetupServices>()!.GetConnectionStrings();
        serviceProvider.GetService<SetupServices>()!.GetEntitySettings();
    }
}