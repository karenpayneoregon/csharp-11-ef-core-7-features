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
        await MainConfiguration.Setup();
        Console.WriteLine(EntitySettings.Instance.CreateNew.ToYesNo());

        AnsiConsole.MarkupLine($"[cyan]MainConnection exists[/] [yellow]{JsonHelpers.MainConnectionExists().ToYesNo()}[/]");

        Console.ReadLine();
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
                    Console.WriteLine("MainConnection exists: " + mainConnection.GetString());
                }
                else
                {
                    Console.WriteLine("MainConnection does not exist.");
                }
            }
            else
            {
                Console.WriteLine("ConnectionStrings section does not exist.");
            }
        }
        else
        {
            Console.WriteLine("appsettings.json not found.");
        }
    }
}
