using EntityCoreFileLogger;
using Microsoft.EntityFrameworkCore;
using PayneServiceLibrary;
using PayneServiceLibrary.Classes.Configuration;
using RazorHasData.Classes;
using RazorHasData.Data;

namespace RazorHasData;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        /*
         * Setup for connection string and mocking data
         */
        await MainConfiguration.Setup();

        builder.Services.AddRazorPages();
        

        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddDbContextPool<Context>(options =>
                options.UseSqlServer(DataConnections.Instance.MainConnection)
                    .EnableSensitiveDataLogging()
                    .LogTo(action: new DbContextToFileLogger().Log));
        }
        else
        {
            builder.Services.AddDbContextPool<Context>(options =>
                options.UseSqlServer(DataConnections.Instance.MainConnection)
                    .LogTo(action: new DbContextToFileLogger().Log));
        }



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
