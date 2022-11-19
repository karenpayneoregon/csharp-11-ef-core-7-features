using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace TableSplittingSample
{
    internal partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample: EF Core table splitting from Microsoft";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Fill);
        }
    }
}
