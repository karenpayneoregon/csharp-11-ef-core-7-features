using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ConsoleHelperLibrary.Classes;
using KarenConsoleApplication.Data;
using Microsoft.EntityFrameworkCore;
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

    }
}
