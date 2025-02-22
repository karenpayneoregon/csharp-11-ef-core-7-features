using System;
using KarenConsoleApplication.Classes;
using KarenConsoleApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Pri.ConsoleApplicationBuilder;
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

        static void Main(string[] args)
        {

            var builder = ConsoleApplication.CreateBuilder(args);
            
            var useLogging = builder.Configuration.GetSection(AppSettings.LogPath).GetValue<string>(AppSettings.UseLogging);

            if (Enum.TryParse(useLogging,true,out ProgramLoggingType plt))
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
            
            var customers = ops.GetCustomers();
            Console.WriteLine(ObjectDumper.Dump(customers));

            SpectreConsoleHelpers.ExitPrompt();
        }
    }
}







