using CheckSectionExistsAppSettings.Classes;
using Serilog;

namespace CheckSectionExistsAppSettings;

internal partial class Program
{
    /// <summary>
    /// EntityConfiguration is set to EntityConfiguration1
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    static async Task Main(string[] args)
    {
        await Task.Delay(0);
        //await MainConfiguration.Setup();
        //Console.WriteLine(EntitySettings.Instance.CreateNew.ToYesNo());

        //AnsiConsole.MarkupLine($"[cyan]MainConnection exists[/] [yellow]{JsonHelpers.MainConnectionExists().ToYesNo()}[/]");
        MainSectionExists();
        SpectreConsoleHelpers.ExitPrompt();
    }


    static void MainSectionExists()
    {
        string filePath = "appsettings.json"; 

        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            using JsonDocument doc = JsonDocument.Parse(jsonString);

            if (doc.RootElement.TryGetProperty("ConnectionStrings", out JsonElement connectionStrings))
            {
                if (connectionStrings.TryGetProperty("MainConnection", out JsonElement mainConnection))
                {
                    Log.Information("MainConnection exists: {P}", mainConnection.GetString());
                }
                else
                {
                    Log.Information("MainConnection does not exist.");
                }
            }
            else
            {
                Log.Information("ConnectionStrings section does not exist.");
            }
        }
        else
        {
            Log.Information("appsettings.json not found.");
        }
    }
}
