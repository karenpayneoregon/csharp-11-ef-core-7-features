using KeyedServiceProject1.Classes;
using KeyedServiceProject1.Interfaces;
using Serilog;
using Serilog.Events;

namespace KeyedServiceProject1;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        builder.Services.AddKeyedTransient<INotificationService, 
            FirstNotification>(ServiceKeys.FirstDemo);

        builder.Services.AddKeyedTransient<INotificationService, 
            SecondNotification>(ServiceKeys.SecondDemo);


        //SetupLogging.Development();
        //builder.Services.AddSerilog();

        // Configure Serilog
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("System", LogEventLevel.Warning)
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();

        builder.Host.UseSerilog();

        var app = builder.Build();
        //app.UseSerilogRequestLogging();
        // Configure the HTTP request pipeline.
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

        app.Run();
    }
}
