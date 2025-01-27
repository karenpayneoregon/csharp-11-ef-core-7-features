using PayneServiceLibrary;
using System.Windows;

namespace WpfHasData
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Setup().Wait();
        }

        private async Task Setup()
        {
            await MainConfiguration.Setup();
        }
    }
}
