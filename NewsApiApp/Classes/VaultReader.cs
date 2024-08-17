using System.Reflection;
using Microsoft.Extensions.Configuration;
using NewsApiApp.Models;

namespace NewsApiApp.Classes;

public class VaultReader
{
    public static T ReadProperty<T>(string sectionName, string name) 
        => ConfigurationBuilder<T>()
            .Build()
            .GetSection(sectionName).GetValue<T>(name);

    private static IConfigurationBuilder ConfigurationBuilder<T>()
    {
        var environment = GetWorkingEnvironment();

        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddEnvironmentVariables();

        if (environment == EnvironmentType.Development)
            builder.AddUserSecrets(Assembly.GetExecutingAssembly());

        return builder;
    }

    public static EnvironmentType GetWorkingEnvironment() =>
        Environment.GetEnvironmentVariable("CONSOLE_ENVIRONMENT") switch
        {
            "Development" => EnvironmentType.Development,
            "Production" => EnvironmentType.Production,
            _ => EnvironmentType.Development
        };

    public static string Key
     => ReadProperty<string>(nameof(SecretVault), nameof(SecretVault.Key));


}