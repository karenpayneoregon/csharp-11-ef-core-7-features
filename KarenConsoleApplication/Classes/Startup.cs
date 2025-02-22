using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ConsoleHelperLibrary.Classes;
using KarenConsoleApplication.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace KarenConsoleApplication.Classes
{
    class Startup
    {
        /// <summary>
        /// Initializes the console application by setting the console title and positioning the console window.
        /// </summary>
        /// <remarks>
        /// This method is marked with the <see cref="ModuleInitializerAttribute"/> to ensure it is executed 
        /// automatically before the first access to any type in the assembly.
        /// </remarks>
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "ConsoleApplicationBuilder";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        }

        /// <summary>
        /// Checks if the database associated with the provided <see cref="Context"/> exists.
        /// </summary>
        /// <param name="context">The database context to check for the existence of the database.</param>
        /// <returns>
        /// <c>true</c> if the database exists; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the database creator service is not available in the provided context.
        /// </exception>
        public static bool DatabaseExists(Context context)
        {
           
            if (context.GetService<IDatabaseCreator>() is not RelationalDatabaseCreator databaseCreator)
            {
                throw new InvalidOperationException("Database creator service is not available.");
            }

            return databaseCreator.Exists();
        }
    }
}
