using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KarenConsoleApplication.Classes;
using KarenConsoleApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Pri.ConsoleApplicationBuilder;
using Serilog;
using Spectre.Console;

namespace KarenConsoleApplication
{
    /// <summary>
    /// Represents the entry point of the app.
    /// </summary>
    /// <remarks>
    /// This class is responsible for initializing logging, configuring services, setting up the database context, 
    /// and building the application using the ConsoleApplicationBuilder. It also contains the main execution logic 
    /// for running the application.
    /// </remarks>
    internal class Program(Context context)
    {
        /// <summary>
        /// Initializes logging, configures services, sets up the database context, and builds the application.
        /// Uses the ConsoleApplicationBuilder to configure and run the application.
        /// </summary>
        /// <remarks>
        /// Consider folding Main once configuration is done and focus on Run.
        /// </remarks>
        static void Main(string[] args)
        {
            SetupLogging.Initialize();

            IConsoleApplicationBuilder builder = ConsoleApplication.CreateBuilder(args);

            // get settings from appsettings.json to determine logging behavior
            // not for SeriLog
            var useLogging = builder.Configuration.GetSection(AppSettings.LogPath)
                .GetValue<string>(AppSettings.UseLogging);

            if (Enum.TryParse(useLogging, true, out ProgramLoggingType plt))
            {
                if (plt == ProgramLoggingType.None)
                {
                    builder.Logging.SetMinimumLevel(LogLevel.None);
                }
            }

            builder.Services.AddDbContextPool<Context>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString(AppSettings.DataBaseConnection))
                   .EnableSensitiveDataLogging()
                   .LogTo(new DbContextToFileLogger().Log, [RelationalEventId.CommandExecuted]));

            builder.Services.AddScoped<DataOperations>();
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            var program = builder.Build<Program>();



            program.Run();
        }

        /// <summary>
        /// Executes the main logic of the application, including database checks, data retrieval, 
        /// script generation, and logging operations.
        /// </summary>
        /// <remarks>
        /// This method performs the following tasks:
        /// - Verifies the existence of required database tables.
        /// - Retrieves customer data and outputs it to the console.
        /// - Generates and saves database scripts to a file.
        /// - Logs the start and end of the process.
        /// - Prompts the user for exit confirmation.
        /// </remarks>
        /// <exception cref="System.IO.IOException">
        /// Thrown when an error occurs while writing the database script to a file.
        /// </exception>
        private void Run()
        {
            var ops = new DataOperations(context);

            Log.Information("Start");


            if (DbContextHelpers.FullCheck(context, "Customer", "ContactTypes", "Genders"))
            {
                var customers = ops.GetCustomers();
                Console.WriteLine(ObjectDumper.Dump(customers));
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Create the database and run the script under[/][cyan] Data scripts[/]");
            }

            var scripts = DbContextHelpers.GenerateScripts(context);
            File.WriteAllText("script.sql",scripts);
            Log.Information("Bye");
            Log.CloseAndFlush();

            SpectreConsoleHelpers.ExitPrompt();
        }
    }
}







