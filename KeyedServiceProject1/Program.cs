using KeyedServiceProject1.Classes;
using KeyedServiceProject1.Interfaces;

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
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
