using PeriodicTimerWebApp.Classes;


namespace PeriodicTimerWebApp;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.AddSingleton<TimerOperations>();
        
        builder.Services.Configure<ConnectionOptions>(
            builder.Configuration.GetSection(nameof(ConnectionOptions)));

        SetupLogging.Development();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();
        app.MapRazorPages();
        app.SetConsoleWindowTitle("PeriodicTimer demo");
        app.Run();
    }
}
