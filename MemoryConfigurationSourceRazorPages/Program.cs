using ConsoleConfigurationLibrary.Models;
using CustomIConfigurationSourceSample.Data;
using MemoryConfigurationSourceRazorPages.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Memory;
using Serilog;

namespace MemoryConfigurationSourceRazorPages;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure Serilog
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();

        builder.Host.UseSerilog();

        // Register DbContext
        builder.Services.AddDbContext<Context>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString(nameof(ConnectionStrings.MainConnection))));

        // Add Configuration Sources
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddInMemoryCollection(DataOperations.GetHelpDeskValues());

        //  Build service provider
        var serviceProvider = builder.Services.BuildServiceProvider();

        //  Build configuration and register it in DI
        var configuration = configurationBuilder.Build();
        builder.Services.AddSingleton<IConfiguration>(configuration);

        // Add services to the container.
        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapRazorPages()
           .WithStaticAssets();

        app.Run();
    }
}
