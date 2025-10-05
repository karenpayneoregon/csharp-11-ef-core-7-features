using PayneServiceLibrary;
using System.Windows;
using Serilog;
using WpfHasData.Classes;

namespace WpfHasData
{
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {

            try
            {
                base.OnStartup(e);
                await Setup();
                SetupLogging.Initialize();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failure in OnStartup");
            }
        }
        private async Task Setup()
        {
            await MainConfiguration.Setup();
        }
    }
}
