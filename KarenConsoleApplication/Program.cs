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
    class Program
    {
        public Program(Context context)
        {
            _context = context;
        }

        private readonly Context _context;

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

            var builder = ConsoleApplication.CreateBuilder(args);

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

        private void Run()
        {
            var ops = new DataOperations(_context);

            Log.Information("Start");


            if (DbContextHelpers.FullCheck(_context, "Customer", "ContactTypes", "Genders"))
            {
                var customers = ops.GetCustomers();
                Console.WriteLine(ObjectDumper.Dump(customers));
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Create the database and run the script under[/][cyan] Data scripts[/]");
            }



            Log.Information("Bye");
            Log.CloseAndFlush();

            SpectreConsoleHelpers.ExitPrompt();
        }
    }
}







