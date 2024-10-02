using KeyedServiceProject1.Classes;
using KeyedServiceProject1.Interfaces;
using Serilog;
using SeriLogThemesLibrary;

namespace KeyedServiceProject1;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        builder.Services.AddKeyedTransient<INotificationService, 
            FirstNotification>(ServiceKeys.First);

        builder.Services.AddKeyedTransient<INotificationService, 
            SecondNotification>(ServiceKeys.Second);


        SetupLogging.Development();
        //builder.Services.AddSerilog();


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
